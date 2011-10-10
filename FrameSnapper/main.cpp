extern "C"
{
#include "libavcodec/avcodec.h"
#include "libavformat/avformat.h"
#include "libswscale/swscale.h"
}

#define DLLEXPORT extern "C" __declspec(dllexport)



void GetFrame(AVFrame *pFrame, int width, int height, int iFrame, char** outbuffer, int* bufsize) 
{
	*bufsize = width*3*height;
	char* buf = (char*)av_malloc(width*3*height);
	memcpy (buf, pFrame->data[0], width*3*height);

	*outbuffer = buf;
}

DLLEXPORT void CleanUpFrame (char* buffer)
{
	av_free(buffer);
}

DLLEXPORT int GrabFrame (char* file, double seek, int* outwidth, int* outheight, char** outbuffer, int* bufsize)
{
	av_register_all();

	AVFormatContext *pFormatCtx;

	int err = av_open_input_file(&pFormatCtx, file, NULL, 0, NULL);
	if(err != 0)
	{
		return 1; // Couldn't open file
	}

	// Retrieve stream information
	if(av_find_stream_info(pFormatCtx)<0)
	{
		return 2; // Couldn't find stream information
	}

	// Dump information about file onto standard error
	dump_format(pFormatCtx, 0, file, 0);

	unsigned int i;
	AVCodecContext *pCodecCtx;

	// Find the first video stream
	int videoStream=-1;

	for(i=0; i<pFormatCtx->nb_streams; i++)
	{
		if(pFormatCtx->streams[i]->codec->codec_type==CODEC_TYPE_VIDEO) 
		{
			videoStream=i;
			break;
		}
	}

	if(videoStream==-1)
		return 3; // Didn't find a video stream

	// Get a pointer to the codec context for the video stream
	pCodecCtx=pFormatCtx->streams[videoStream]->codec;

	AVCodec *pCodec;

	// Find the decoder for the video stream
	pCodec=avcodec_find_decoder(pCodecCtx->codec_id);

	if(pCodec==NULL) 
	{
		fprintf(stderr, "Unsupported codec!\n");
		return 4; // Codec not found
	}

	// Open codec
	if(avcodec_open(pCodecCtx, pCodec)<0)
	{
		return 5; // Could not open codec
	}

	AVFrame *pFrame;

	// Allocate video frame
	pFrame=avcodec_alloc_frame();

	// Allocate an AVFrame structure
	AVFrame* pFrameRGB = avcodec_alloc_frame();
	if(pFrameRGB==NULL)
	{
		return 6;
	}

	uint8_t *buffer;
	int numBytes;
	// Determine required buffer size and allocate buffer
	numBytes=avpicture_get_size(PIX_FMT_BGR24, pCodecCtx->width, pCodecCtx->height);

	buffer=(uint8_t *)av_malloc(numBytes*sizeof(uint8_t));

	// Assign appropriate parts of buffer to image planes in pFrameRGB
	// Note that pFrameRGB is an AVFrame, but AVFrame is a superset
	// of AVPicture
	avpicture_fill((AVPicture *)pFrameRGB, buffer, PIX_FMT_BGR24, pCodecCtx->width, pCodecCtx->height);

	int frameFinished;
	AVPacket packet;

	i=0;

	AVRational base = {1, AV_TIME_BASE};
	int64_t seekpos = av_rescale_q( (int64_t)(seek * pFormatCtx->duration), base, pFormatCtx->streams[videoStream]->time_base);

	// Find the keyframe just before the seek point
	av_seek_frame(pFormatCtx, videoStream, seekpos, AVSEEK_FLAG_BACKWARD);

	printf("Reading frame: %d\n", seekpos);

	*outwidth = pCodecCtx->width;
	*outheight = pCodecCtx->height;

	while(av_read_frame(pFormatCtx, &packet)>=0) 
	{
		// Is this a packet from the video stream?
		if(packet.stream_index==videoStream) 
		{
			// Decode video frame
			avcodec_decode_video(pCodecCtx, pFrame, &frameFinished, packet.data, packet.size);

			// Did we get a video frame?
			if(frameFinished && pFormatCtx->streams[videoStream]->cur_dts >= seekpos) 
			{
				// Convert the image from its native format to RGB
				//img_convert((AVPicture *)pFrameRGB, PIX_FMT_RGB24, (AVPicture*)pFrame, pCodecCtx->pix_fmt, pCodecCtx->width, pCodecCtx->height);
				SwsContext* img_convert_ctx = sws_getContext(pCodecCtx->width, pCodecCtx->height, pCodecCtx->pix_fmt, pCodecCtx->width, pCodecCtx->height, PIX_FMT_BGR24, SWS_BICUBIC, NULL, NULL, NULL);

				sws_scale(img_convert_ctx, pFrame->data, pFrame->linesize, 0, pCodecCtx->height, pFrameRGB->data, pFrameRGB->linesize);

				GetFrame(pFrameRGB, pCodecCtx->width, pCodecCtx->height, i, outbuffer, bufsize);
				break;
			}
		}

		// Free the packet that was allocated by av_read_frame
		av_free_packet(&packet);
	}

	// Free the RGB image
	av_free(buffer);
	av_free(pFrameRGB);

	// Free the YUV frame
	av_free(pFrame);

	// Close the codec
	avcodec_close(pCodecCtx);

	// Close the video file
	av_close_input_file(pFormatCtx);

	return 0;
}
