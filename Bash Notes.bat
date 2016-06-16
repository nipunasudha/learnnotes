@use formatting 'SHELL'
@Theme Bespin

+++ Relative path 'home/Nipuna'
+++ Absolute path '/home/Nipuna'
ls
------------show the content of the curren directory
	-a
	also list the files and directories starting with a dot (.)
	-l
	returns the longer version
	-alt

pwd
------------currrent absolute path (print working directory)
cd
------------change directory
cd ..  (cd<space>..)
------------go one step back
	cd ../../action
	go back two times and then go into action folder.
touch mytextfile.txt
------------make a text file
cp a.txt b.txt
------------copy content from a to b.
cp a.txt b.txt mydir1
cp a.txt mydir2
cp * ../mynewdir/
cp m*.txt scifi/
_________________________________
mv a.txt b.txt
mv a.txt b.txt mydir1
mv a.txt mydir2
mv * ../mynewdir/
mv m*.txt scifi/
_________________________________
rm a.txt
rm -r comedy    #here -r is for recursive.

echo "Hello!"
------------prints it on display.
echo "Nipuna" > mytext.txt
------------prints into the text file
cat mytext.txt
------------reads and prints data from file.
rmdir myfolder
-----------------remove folder
rm -rf myfolder
-f = to ignore non-existent files, never prompt
-r = to remove directories and their contents recursively
----------------------- CHMOD ------------------------------

chmod has permission arguments that are made up of 3 components

1)Who are we changing the permission for? [ugoa] - user (or owner), group, others, all
2)Are we granting or revoking the permission - indicated with either a plus ( + ) or minus ( - )
3)Which permission are we setting? - read ( r ), write ( w ) or execute ( x )

chmod u+rwx myfile.txt
or
chmod u +r +w +x myfile.txt

-------------------------------------------------------------
