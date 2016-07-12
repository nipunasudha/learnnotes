<?php
=====================get data from GET method===========================
      echo 'Hello ' . htmlspecialchars($_GET["name"]) . '!';

=====================get data from POST method=====================
------Form
      <form action="test.php" method=POST>
       	Name:<br><input type="text" name="name"><br>
       	<input type="submit" value="Submit">
       </form>
 ---- PHP
      echo ($_POST['name']);
===================== Using reqest for both GET & POST
The $_REQUEST variable is a variable with the contents of $_GET and $_POST and $_COOKIE variables.

      echo ($_REQUEST['name']);



















 ?>
