_____________________________________________________________________________

Vue JS Magic Spells!



@) How we define Vue.

		new Vue({       //this is a vue instance. can be assigned to a variable like vm=new Vue()
		  el: '#app',
		  data: {
			message: 'Hello Vue.js!'
		  }
		})
@) types of options
		data, template, element to mount on, methods, lifecycle callbacks

@) for two way binding

		<input v-model="message">

@) FOR loop

		<li v-for="todo in todos">
			@{{ todo }}
		</li>

@) Event hangling

		<button v-on:click="function_to_run">Click me!</button>
		new Vue({
			el: '#app4',
			methods: {
			  function_to_run: function () {
				//do whatever you want
			  }
			}
		  })
		  
		##### MORE ######
		v-on:click="function_to_run"
		v-on:keyup.enter="addTodo"

@) String manipulation

	message = message.split('').reverse().join('')

@) Data manipulation

		--array push
			todos.push({ 'key': 'value' })

@) IF condition

		<p v-if="greeting">Hello!</p>

@hooks (we can add custom logic into these)
		created
		compiled
		ready
		destroyed
		









		
++++++++++++++++++++++++++++++++++++++++++++++++++++++++
++++++++++++++++++++++++++++++++++++++++++++++++++++++++
++++++++++++++++++++++++++++++++++++++++++++++++++++++++
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
					@{{ todo }}
				</li>
			</ul>
		</div>


		new Vue({
		  el: '#app3',
		  data: {
			todos: [
				'Learn JavaScript' ,
				'Learn Vue.js' ,
				'Build Something Awesome'
			  ]
		  }
		})

#click (event) handling

		<div id="app4">
			<p>@{{ message }}</p>
			<button v-on:click="reverseMessage">Reverse Message</button>
		  </div>

		new Vue({
			el: '#app4',
			data: {
			  message: 'Hello Vue.js!'
			},
			methods: {
			  reverseMessage: function () {
				this.message = this.message.split('').reverse().join('')
			  }
			}
		  })
		  
		  
		  
		  
		  
		  
		  
		  





