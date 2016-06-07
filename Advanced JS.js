@use formatting 'Javascript'
@Theme Bespin

'Javascript Advanced'

------------ Binding to dynamic DOM ---------------------
$('#big-container').delegate('#dynamic-item','click',function(){/*dostuff*/});

------------ finding parent by CLOSEST ------------------
$(this).closest('.my-div').hide();

------------ Mustache Templating ------------------
NOT ONLY FOR LARAVEL!
1)import mustache.min.js
	<script src= "{{ URL::asset('tools\mustache.min.js') }}"></script>
2)create the <template> tag. **put @ because its laravel.

	<template id="info-template">
		<p>
		  hah! This is a text, with @{{name}} and @{{drink}}
		</p>
		<input type="text" name="name" value="">
		<input type="button" name="name" value="Click here!">
	  </template>
	  
3) Code to render the template!

	$('#orders').append(
		Mustache.render($('#info-template').html(),newOrder)
	);
	
4)Thats it!

------------------------------------------------------------