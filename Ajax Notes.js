@use formatting 'Javascript'
@Theme Bespin

-----------------------------------------------------
Requesting & Displaying a JSON response

	<script>
		$('#add').on('click',function(){
		  $.ajax({
			type:'GET',
			url:'/getjson',
			success:function(data){
			  alert(data.name);
			},
			error:function(){
				alert('bad URL!');
			}
			})
		})
	</script>
	
-----------------------------------------------------
Responding to a JSON request (In a Laravel Controller)	

	public function test(){
      return response()->json(['name' => 'Nipuna Sudharaka', 'drink' => 'Coffee']);
    }


-----------------------------------------------------
POST from AJAX to Laravel

1) On the view.

  var $name=$('#name');
  var $drink=$('#drink');
  var order={
    name:$name.val(),
    drink:$drink.val()
  };
  $.ajax({
    type:'POST',
    url:'/postjson',
    data:order,
    success:function(newOrder){
     $('#orders').append('<li>'+newOrder.name + ' - ' + newOrder.drink + '</li>');

    },
    error:function(){
      alert('bad URL!');
    }
	})

##### Global way to avoid '500 internal server error' in Laravel:-

	In this way we will add token for globally work with ajax call or post. 
	so no need to send it with data post.

	1. Add a meta tag to your layout header :- csrf_token() will be the 
	same as "_token" CSRF token that Laravel automatically adds in the 
	hidden input on every form.

			<meta name="_token" content="{!! csrf_token() !!}"/>

	2. Now add below code to footer of your layout, or where it will set 
	for globally or whole site pages. this will pass token to each ajax request.

			<script type="text/javascript">
			$.ajaxSetup({
			   headers: { 'X-CSRF-Token' : $('meta[name=_token]').attr('content') }
			});
			</script>
	Now make an ajax post request an you are done your data will post successfully.

##### Individual way to avoid '500 internal server error' in Laravel:-

<button type="button" class="confirm-btn" data-token="{{ csrf_token() }}">Confirm</button>
------------------
var token = $(this).data('token');

    $.ajax({
        url:route,
        type: 'post',
        data: {_method: 'delete', _token :token},
        success:function(msg){
-------------------

-----------------------------------------------------
DELETE from AJAX to Laravel

	Route::delete('/deletejson', 'JsonRespondController@test3');

	  public function test3(Request $request){ //in the JsonRespondController
		  return response()->json(['message' => $request->id]);
	  }

	$('#deletebutton').on('click',function(){ //in the script

	  $.ajax({
		type:'post',
		url:'/deletejson',
		data: {_method: 'delete',id:'0714355447'}, <----LOOK AT THIS
		success:function(newOrder){
		  alert(newOrder.message);
		},
		error:function(){
		  alert('bad URL!');
		}
	  })
	})





