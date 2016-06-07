@use formatting 'C#'
@Theme Bespin

##Structure##
	1)Models
	2)Controllers
	3)Routs
	4)Views

##Installation##
	1)download composer for windows
	2)Set path to php in Xampp
	3)Install composer
	4)Restart
	5)in CMD-----> composer global require "laravel/installer"
	6)Create a new folder for projects
	7)in CMD-----> laravel new myApp
					cd myApp
					php artisan serve
	8)go to localhost:8000 in web browser
	
##Folder Structure##
	App
		App logic
		models
		conrollers
		services
	config
		config files
	public
		where the virtual host points to
	resources
		all the things the frontend user sees
	storage
		caches and logs
	tests
		unit tests
	vendor
		3rd party libraries
	composer.jsom
		assigning a composer
	.env file
		database credentials
	routs.php
		all the routes
##Rout file##
	Route::get('/', function () {
		return view('welcome');
	});
	Route::get('user/{name}', function ($name) {
		echo "your name is ".$name;
		
	});
	//create an item
	Route::post();
	//read an item
	Route::get();
	//update an item
	Route::put();
	//delete an item
	Route::delete();

##running / calling controllers##
	Route::get('test2','TestController@index');
	
##reading from a database! its fucking easy##
## and MODELS
	1) create database
	2) edit .env file to access the database
	3) in /app create a php file (tableName:students phpFile:student.php)
		<?php
			namespace App;
			use Illuminate\Database\Eloquent\Model;
			class student extends Model
			{}
		?>
---- UPDATE ----------------------------------------------------------------------
		You can define which table to link in this way!
			<?php
				namespace App;
				use Illuminate\Database\Eloquent\Model;
				class Task extends Model
				{
					protected $table = 'tasks';
				}
			?>
----------------------------------------------------------------------------------
		
	4) in /app/http/routes.php

		Route::get('student/{userid}',function($userid){
			$customer=App\student::find($userid);
			echo "you searched for index ".$userid;
			echo "my name is ".$customer->name;
		});
	5) go to "student/1" and it will show the student 1 details
	
##Relationships of tables##
	--------- ගල් යුගයේ විදිය
		Route::get('reports',function(){
			foreach (App\report::all() as $k) {
				$student=App\student::find($k->student_id)->name;
				echo "<p>".$k->name." from ".$student."</p>";
			}
		});
	--------- හරි විදිය

	Route::get('reports',function(){
		foreach (App\report::all() as $aReport) {
			
			echo "<p>".$aReport->name." from ".$aReport->student->name"</p>";
		}
	});

	To do this we have to define a relationship
	**** we say 'report' to return the matching record 
	**** that belongs to 'student'.
	**** matching field is detected like this...
	**** student_id in 'report' table belongs to 'student'

		<?php
		namespace App;
		use Illuminate\Database\Eloquent\Model;
		class report extends Model
		{
			public function student(){
				return $this->belongsTo('App\student'); //RESTful way
				return $this->hasOne('App\Phone', 'foreign_key', 'local_key'); //do it your self
			}
		}
		?>	
	ඒ් විදියෙ terms
		belongsTo
		hasMany

##View a html file from routes.php##
	Route::get('mypage',function(){
		echo view('tr/index');
	});		

##Passing data to .php file through routes.php##
	1)create an array of data you need
	2)send it with the view command.
	3) in <?php ?> use them :)

	------in routes.php
	Route::get('mypage',function(){
		$studentlist=App\student::all();
		$array = array( 'studentlist'=>  $studentlist);	
		echo view('page',$array);
	});	
	-----in page.php
	<body>
		<h1>
			<?php
				foreach($studentlist as $st){
					echo $st->name."<br>";
				}
			?>
		</h1>
	</body>	

##Blade templating## (this is gonna be fucking awesome!)
	1)just rename your sample.php to sample.blade.php
	2)instead of fucking with <?php ?> use this syntax anywhere in the php.
		--------------------------------------------------------------------------------
		@foreach($studentlist as $cus)
			<p>dont fuck with me {{$cus->name}}</p>
		@endforeach
		--------------------------------------------------------------------------------
		@if(condition)
			<p>this is anything html</p>
			{{this is anything logical}}
		$endif
		--------------------------------------------------------------------------------
		--------------------------------------------------------------------------------
		--------------------------------------------------------------------------------
		--------------------------------------------------------------------------------
		--------------------------------------------------------------------------------
		--------------------------------------------------------------------------------
	
##MasterBlade 
	----------master.blade.php
		<!DOCTYPE html>
		<html>
		<head>
		<title></title>
		</head>
		<body>
		@yield('main_content')
		</body>
		</html>
	-----------page.blade.php
		@extends('master')
		@section('main_content');
			<h1>
				@foreach($studentlist as $cus)
					<p>dont fuck with me {{$cus->name}}</p>{{2+2/0.7}}
				@endforeach
			</h1>
		@stop	
		
		
##path defining!##
	code:
		use App\models\reports\students as student;  //on the top of the php
	and use student! 

##Super easy .bat files##
	Batch file to create controllers:
		@echo off
		cd..
		ECHO Enter name for the controller
		set /p controllername=: 
		php artisan make:controller %controllername%
	Batch file to run the localhost:
		@echo off
		cd..
		start http://localhost:8000
		php artisan serve
##Controllers##
	
	---------in routes.php:
		Route::get('showwhatisay/{thing}','StudentController@show');
		Route::get('listall','StudentController@list');
			here:
				thing--->this variable can be used as '$thing' in the controller
				StudentController--->controller name
				show/list-->called function name
	---------in StudentController.php:
		<?php
			namespace App\Http\Controllers;
			use Illuminate\Http\Request;
			use App\Http\Requests;
			use App\student as student;//this is the path definition
			class StudentController extends Controller
			{
				public function show($thing){
					echo $thing;
				}
				public function list(){
					$list=student::all();
					foreach($list as $item){
						echo $item->name."<br>";
					}
				}
			}
		?>
	
##Authentication##
	1)First click on the 'Migrate.bat' File.
	-------------File content:
		@echo off
		cd..
		php artisan migrate
		pause >nul
	2)Just click on the 'Make login.bat' File.
	-------------File content:
		@echo off
		cd..
		php artisan make:auth
	
	
##Middleware - It's no joke! ###
	1)Built in middleware
		We are gonna use "app/http/middleware/authentication.php" to authnticate users
			-----in routes
				Route::get('/joke', ['middleware'=>'auth',function(){
				echo "Ah you are allowed to have fun! :D";
				}]);
	2)User defined middleware
		This thing was not 100% clear. Find that out.

##Migration Files##
	1)basic table creating syntax
		<?php
			use Illuminate\Database\Schema\Blueprint;
			use Illuminate\Database\Migrations\Migration;
			class CreateUsersTable extends Migration
			{
				public function up()
				{
					Schema::create('users', function (Blueprint $table) {
						$table->increments('id');
						$table->string('name');
						$table->string('email')->unique();
						$table->string('password');
						$table->rememberToken();
						$table->timestamps();
					});
				}
				public function down()
				{
					Schema::drop('users');
				}
			}
		?>
		-------------------- Migrate rollback.php
			@echo off
			cd..
			php artisan migrate:rollback
			pause >nul
	
	2) Database Seeding
		---------- CMD command to create a seeder
			php artisan make:seeder UsersTableSeeder
		---------- database/seeds/UsersTableSeeder.php
			<?php
				use Illuminate\Database\Seeder;
				use Illuminate\Database\Eloquent\Model;
				class DatabaseSeeder extends Seeder
				{
					public function run()
					{
						DB::table('users')->insert([
							'name' => str_random(10),
							'email' => str_random(10).'@gmail.com',
							'password' => bcrypt('secret'),
						]);
					}
				}
			?>
			
		2.1) Or use model factories //search & understand the code
			public function run()
			{
				factory(App\User::class, 50)->create()->each(function($u) {
					$u->posts()->save(factory(App\Post::class)->make());
				});
			}
		2.2)Running seeds
		//add seeds to all the classes
			php artisan db:seed
		//add seeds to UsersTableSeeder class
			php artisan db:seed --class=UsersTableSeeder
		//migrate & seed (complete rebuild);
			php artisan migrate:refresh --seed

##Requests##
	***** print_r($myArray); //this one prints a whole array! 
		//Array([name]=>xxx [id]=4343) like this
	
	------- In routes.php
	Route::get('/myForm1',function(){    //just desplaying the form
		return view('formPage1');
	});		
		
	use Illuminate\Http\Request; //--------------Import request class
	
	Route::post('postingTarget1',function(Request $req1){    //geting info from page
		$name = $req1->input('name');                       // getting what we need
		echo "You entered ". $name;
	});		
		---------------- OR ------------------
	Route::post('postingTarget1',function(Request $req1){    //geting info from page
		$myAllthings = $req1->all();                       // getting what we need
		print_r($myAllthings);                            // print the array
	});	
		
## CSRF Tokens ##		
		
	This is the token for forms (add this before submit button)	
		-------------------------------------------------------------------------	
			<input type="hidden" name="_token" value="{{ csrf_token() }}">	
		-------------------------------------------------------------------------	
			
	To use forms without csrf_token, remove this line from "Kernal.php"
		-------------------------------------------------------------------------
			 \App\Http\Middleware\VerifyCsrfToken::class
		-------------------------------------------------------------------------
## CSS and JS !!! ##	
	
	Best way to add CSS
		<link href="{{ URL::asset('css/style.css') }}" rel="stylesheet"> //this goes to public
	Best way to add JS	
		<script src= "{{ URL::asset('js/script.js') }}"></script> //this goes to public
		
		
##Get User ID Within Custom Controller##		
		use Auth;
		First test if user is logged in with if (Auth::check())
		Auth::user()->id	
	//in the routes.php file you dont have to import Auth :)
	
## HTML Requirable Package ##	
	import by entering
		composer require illuminate/html
	BUT!!!
		bindShared has been renamed to $app->singleton()

## DD helper ##
	In a controller, use dd in the store function to dump the submitted data.
		public function store(Request $request)
		{
			dd($request->all());
		}

## Database READING step by step
	0)Edit .env file
	1)Create a migration file
		php artisan make:migration myTable --create=tasks
	2)Edit it to match your needs.
	3) Migrate
	4) Make a model for the table
	5) In routes.php, import these. (optional)
			use App\Animal; //<---- Task is the model name
			use Illuminate\Http\Request;
	6) and add a route,
			Route::get('sample', function () {
				$tasks = Animal::orderBy('created_at', 'asc')->get();
				return view('sample', [
					'animals' => $tasks
				]);
			});
	7) in sample.blade.php
			<?php
			print_r($animals->first()->name);
			?>
	8) in the Animal.php

		<?php
		namespace App;
		use Illuminate\Database\Eloquent\Model;
		class Animal extends Model
		{
		   protected $table = 'animals';
		}
	9) and go to "/sample" :)


## Database WRITING step by step

1) add some values, so that table will be editable.
	<?php
		namespace App;
		use Illuminate\Database\Eloquent\Model;
		class Animal extends Model
		{
			protected $fillable = [
				'name',
				'seller_id',
				'collection_id',
				'price',
			];
			protected $table = 'products';
		}
	?>
2) Create 'DataWriteController' and its method 'write_products'
3) Make sure to import
		use App\Product;  //your model
		use Validator;     //for validation

4) Create route

		Route::post('list','DataWriteController@write_products');
5) in DataWriteController@write_products, //add validation logic & false part & true part
		public function write_products(Request $request){

		  $validator = Validator::make($request->all(), [
			  'name' => 'required|max:255',
			  'seller_id' => 'required|max:255',
			  'collection_id' => 'max:255',
			  'price' => 'required|max:255',
		  ]);
		  if ($validator->fails()) {
			  return "Ahhh! You messed up. Re-check the submission.";
		  }
		  $product = new Product;
		  $product->name = $request->name;
		  $product->seller_id = $request->seller_id;
		  $product->collection_id = $request->collection_id;
		  $product->price = $request->price;
		  $product->save();
		  return redirect("list");
		}


## Check if anything is in an array ##
		if($myArray->any()){
			
		}

## file upload ##

	1) create a form with a file & a token
	2) make a controller 'upload controller@imageupload'
	3) route to the function
		Route::post('upload', 'UploadController@upload_image');
		Route::get('upload', function () {
			return view('testviews/upload_image');
		});
	4) you have to manually add that in to aliases array as below,
		'Input' => Illuminate\Support\Facades\Input::class, and add
		use Input;
		to the controller.
		----------------------------------------------------
		OR You can import Input facade directly as required,
		use Illuminate\Support\Facades\Input;
	5)

## using HTML & FORM ##

	Begin by installing this package through Composer. 
	Edit your project's composer.json file to require laravelcollective/html.
		"require": {
			"laravelcollective/html": "5.1.*"
		}
	Next, update Composer from the Terminal:
		composer update
	Next, add your new provider to the providers array of config/app.php:
		'providers' => [
		// ...
		Collective\Html\HtmlServiceProvider::class,
		// ...
		],
	Finally, add two class aliases to the aliases array of config/app.php:
		'aliases' => [
		// ...
		  'Form' => Collective\Html\FormFacade::class,
		  'Html' => Collective\Html\HtmlFacade::class,
		// ...
		],

## Adding images by using HTML helpers ##

		{!! Html::image('img/logo.png') !!}
	or in controllers use
		echo Html::image('uploaded_images/'.$file->getClientOriginalName());


## Error pages like 404 503 ##
	abort(404);

____________________________________________________________________________________

## Laravel Database Queries ##

------------------- GET ALL ROWS FROM TABLE --------------------
//way 1 - Through a model
$tasks = Animal::orderBy('created_at', 'asc')->get();

//way 2 - Directly by using DB facade
$users = DB::table('users')->get();

------------------- WHERE --------------------------------------
$filtered = DB::table('users')->where('name', 'John');

-------------------------- CHUNKS ------------------------------
DB::table('users')->orderBy('id')->chunk(100, function($users) {
    foreach ($users as $user) {
        //
    }
});
//and in this function, RETURN FALSE to stop further proccessing.

-------------------------- PLUCK COLUMNS -----------------------
	$roles = DB::table('roles')->pluck('title', 'name');

--------------------- AGGREGATES -------------------------------
//like ----> count, max, min, avg, and sum.
	$users = DB::table('users')->count();
	$price = DB::table('orders')->max('price');

------------------------ DISTINCT ------------------------------

$users = DB::table('users')->distinct()->get();

------------------------ SELECT --------------------------------


------------------------- JOIN ---------------------------------


------------------------- WHERE --------------------------------
	$users = DB::table('users')->where('votes', '=', 100)->get();
	//OR
	$users = DB::table('users')->where('votes', 100)->get();
	//Operators ---------> =, <, >, <=, >=, <>, like
_______________________________________________________________

You may also pass an array of conditions to the where function:

	$users = DB::table('users')->where([
		['status','1'],
		['subscribed','<>','1'],
	])->get();

------------------------- ORWHERE ------------------------------

	$users = DB::table('users')
						->where('votes', '>', 100)
						->orWhere('name', 'John')
						->get();

------------------------- INSERT -------------------------------
	DB::table('users')->insert(
		['email' => 'john@example.com', 'votes' => 0]
	);

//MULTIPLE

	DB::table('users')->insert([
		['email' => 'taylor@example.com', 'votes' => 0],
		['email' => 'dayle@example.com', 'votes' => 0]
	]);

--------------------- INSERT & GETID ---------------------------

	$id = DB::table('users')->insertGetId(
		['email' => 'john@example.com', 'votes' => 0]
	);

-------------------- UPDATE ------------------------------------

	DB::table('users')
				->where('id', 1)
				->update(['votes' => 1]);
				

---------------- UPDATE--> Increment / Decrement ---------------

	DB::table('users')->increment('votes');
	DB::table('users')->increment('votes', 5);
	DB::table('users')->decrement('votes');
	DB::table('users')->decrement('votes', 5);

------------------------- DELETE -------------------------------

	DB::table('users')->where('votes', '>', 100)->delete();

//clear table & reset Aout-Increment,
	DB::table('users')->truncate();



## FAKERS ##

	$faker->randomDigit;
	$faker->numberBetween(1,100);
	$faker->word;
	$faker->paragraph;
	$faker->lastName;
	$faker->city;
	$faker->year;
	$faker->domainName;
	$faker->creditCardNumber;


## Returning JSON ## (useful for ajax)
	//for JSON
	return response()->json(['name' => 'Abigail', 'state' => 'CA']);
	//for JSONP
	return response()->json(['name' => 'Abigail', 'state' => 'CA'])
					 ->setCallback($request->input('callback'));

## EXTRA -------- See - Json Notes.txt











