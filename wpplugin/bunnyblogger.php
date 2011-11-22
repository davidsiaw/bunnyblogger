<?php
/*
Plugin Name: BunnyBlogger Plugin
Plugin URI: http://labs.astrobunny.net
Description: Plugin to enable BunnyBlogger to work with the blog
Version: 0.0.1
Author: astrobunny
Author URI: http://labs.astrobunny.net
License: GPL2
Notes: nyanyanyanyanyanya
*/

add_filter( 'xmlrpc_methods', 'add_new_xmlrpc_methods' );

function add_new_xmlrpc_methods( $methods ) {
    $methods['bunny.mediumPictureSize'] = 'medium_picture_size';
    //$methods['bunny.getDummyPost'] = 'get_dummy_post';
    $methods['bunny.getAPostId'] = 'get_a_post_id';
    return $methods;
}

function medium_picture_size( $args ) {
	$result = array( 
		width => get_option( 'medium_size_w' ),
		height => get_option( 'medium_size_h' ));


    return $result;
}

function hook_fake_page() {
	global $wp_query;

	if($wp_query->get('p') == 2147483646) {

	  	if($wp_query->is_404 ) {

			$id=2147483646; // need an id
			$post = new stdClass();
				$post->ID= $id;
				$post->post_category= array('uncategorized'); //Add some categories. an array()???
				$post->post_content='@@bunnyblogger_dummy_body'; //The full text of the post.
				$post->post_excerpt= '@@bunnyblogger_dummy_body'; //For all your post excerpt needs.
				$post->post_status='publish'; //Set the status of the new post.
				$post->post_title= '@@bunnyblogger_dummy_title'; //The title of your post.
				$post->post_type='post'; //Sometimes you might want to post a page.
			$wp_query->queried_object=$post;
			$wp_query->post=$post;
			$wp_query->found_posts = 1;
			$wp_query->post_count = 1;
			$wp_query->max_num_pages = 1;
			$wp_query->is_single = 1;
			$wp_query->is_404 = false;
			$wp_query->is_posts_page = 1;
			$wp_query->posts = array($post);
			$wp_query->page=false;
			$wp_query->is_post=true;
			$wp_query->page=false;
		}
	}
}
add_action('wp', 'hook_fake_page');

?>