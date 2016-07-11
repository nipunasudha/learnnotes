----------------------Jquery selectors------------------------

######### Basic selectors

$("elem1,elem2,elem3")
$("elem")
$('li')[0] or $('li').get(0)
$($('li')[0]).fadeOut();

########## Adding to the selection

$("elem").add($('anotherelem'))

######### Select by Atrribute
$("li[data-chosen]").fadeOut(); //selector attr only
$("li[data-chosen=nipuna]").fadeOut();//selector attr value
$("[data-chosen]").fadeOut(); //attr only

######### Wildcard selectors

$("li[data-chosen*=23]").fadeOut(); //contains
$("li[data-chosen^=a]").fadeOut(); //starts with
$("li[data-chosen$=23]").fadeOut(); //end with

######### By position

$("li:first").fadeOut();
$("li:last").fadeOut();
$("li:nth(2)").fadeOut();

########### Filter
$(':button')
$(':checkbox')
$(':password')
$(':submit')
=============
$('contains()')
$('selector:not(selector)')

########### JSON Format

{"firstName":"John", "lastName":"Doe"}

------------------ Chaining -----------------------

$('div').hide().show().fadeOut();

------------ Manipulating DOM -------------------
===== Inside
$('div').html("Nipuna<br>");
$('div').text("Nipuna"); //Only text
$("<li>nipuna</li>").appendTo('div')
$("<li>nipuna</li>").prependTo('div')
$('div').append("<li>this is after</li>")
$('div').prepend("<li>this is after</li>")

===== Outside
$("<li>nipuna</li>").insertAfter('div')
$("<li>nipuna</li>").insertBefore('div')
$('div').after("<li>this is after</li>")
$('div').before("<li>this is after</li>")

===== Copying
$(selector).clone().appendTo(anotherSelector);

===== Create an Element
$('<div>',{         <-------- here put just the opening tag
  'html':"haha haha",
  'class':"mydiv",
  .... etc ...
}).appendTo("body");

===== Replacing
$(selector).replaceAll('<li>Nipuna<li>');
$(selector).replaceWith('<li>Nipuna<li>');

===== Removing
$(selector).remove(); //removing from DOM
$(selector).detach(); //detach for editing, and then appennd
$(selector).empty(); // clear inside

======== Wrapping

### before

<div class="container">
  <div class="inner">Hello</div>
  <div class="inner">Goodbye</div>
</div>

### Jquery

$( ".inner" ).wrap( "<div class='new'></div>" );  //or
$( ".inner" ).wrapAll( "<div class='new'></div>" );

### after

<div class="container">
  <div class="new">
    <div class="inner">Hello</div>
  </div>
  <div class="new">
    <div class="inner">Goodbye</div>
  </div>
</div>

======== Modify Attributes
$("selector").attr("name","value");
$("selector").prop("name","value");
$("selector").removeAttr("name");
$("selector").removeProp("name");

======= CSS
$(elem).css('style','value'); //or JSON Format

======= Class manipulation
.hasClass() //boolean
.addClass("class1 ........")
.removeClass("class");
.toggleClass("class1 .........");

======= Size
.height()
.width()
======= Positioning
//from the offset parent
.position() // returns JSON {top: 50, left: 50}
.position({top: 100, left: 100}) //sets the position
//from the document
.offset()
.offset({top: 100, left: 100})


-------------------- Event Handling ---------------------
#############  on()
  e.stopPropagation() //use this to stop recursing through the DOM
  //example
  $('div').on('click',function(e){ //e is a Event Object
    console.log("Clicked");
    e.stopPropagation(); //recursing stoped
  })
  #############  off()
  $('div').off() //turn off all events
  $('div').off('click') //turn off all events

############ Event Object
//log the object & see the data it has
.currentTarget  //currently recursing element
.type //event type
.which //with key or button pressed
.timestamp //absolute time event occured
.target  // originally clicked element
.data

######### Advanced on()
$(elem).on(event,selector,data,handler)
//selector: to select decendants. so container is binded, but children are clickable.
//data: put {json} and it will be in the Event Object
######### trigger()
$(elem).trigger('click'); //event is programatically occured


-------------------- Browser Event Handling ---------------------

.error(function(){})
.resize()
.scroll() //window or a scrollable element

######### Throwing an error
throw "Fuck!"; //a JS thing, not JQ

######### Form Events
.change()
.focus() --- .blur() //right at it
.focusin() ---- .focusout() //right at it OR A CHILD
.select() //if user selects something in a NESTED TEXTBOX
.submit() // if something NESTED is submitted

######### Keyboard Events
.keydown() //any key
.keypress() //only legit keystrokes, ctrl alt etc don't work
.keyup() // any key
***there you use that "which" data

------------------------------ Effects ----------------------
show()
hide()
toggle()
fadeIn()
fadeOut()
fadeToggle()
fadeTo() // to a opacity level
**** stop() //stop animation
slideUp() //collapse upwards
slideDown() //re-shows the element downwards
------------------------
animate()
//example
$(elem).animate({'height':'700px'},5000); //or {duration:5000}


























---------- Tricks ----------------------------------
#get the value from a dropdown
$(selector).val();
