_____________________________________________________________________________

Vue JS Magic Spells!
_____________________________________________________________________________

#Hello world

1)create a div with id. in that, use templating as needed. 

<div id="app">
  @{{ message }}
</div>

2) put this script.
	*el- select the ODM element to affect
	*data- input the variables needed

		new Vue({ 
		  el: '#app',
		  data: {
			message: 'Hello Vue.js!'
		  }
		})
		
_____________________________________________________________________________

#two way binding

<div id="app2">
  <p>@{{ message }}</p>
  <input v-model="message"> //using v-model, Vue publishes 'message' everywhere.
</div>

new Vue({
  el: '#app2',
  data: {
    message: 'Hello Vue.js!'
  }
})
_____________________________________________________________________________

#rendering a list! For loops

<div id="app3">
  <ul>
    <li v-for="todo in todos">
      @{{ todo.text }}
    </li>
  </ul>
</div>
































