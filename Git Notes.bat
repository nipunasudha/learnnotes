@use formatting 'SHELL'
@Theme Bespin
Git Notes!
#### GIT FLOW DIAGRAM 
--> http://development.rc.ucl.ac.uk/training/carpentry/assets/distributed_concepts_all.png
-----------------------------------------------------------------------
git clone
-----------------------------------------------------------------------
git status
-----------------------------------------------------------------------
git add index.html #add a specific file
git add -A #add all untracked files
-----------------------------------------------------------------------
git commit
-----------------------------------------------------------------------
git push #push to online repo
git push origin --tags #use --tags to push with tags
-----------------------------------------------------------------------
git checkout v1.3 #checkout a specific tag(version)
		This is useful for quickly inspecting an old version 
		of your project. However, since there is no branch reference 
		to the current HEAD, this puts you in a 'detached HEAD' state. 
		This can be dangerous if you start adding new commits 
		because there will be no way to get back to them after you 
		switch to another branch. For this reason, you should always
		'create a new branch before adding commits' to a detached HEAD.
git checkout master #go to the latest commit
-----------------------------------------------------------------------
git pull 
-----------------------------------------------------------------------
git tag #list all the tags you have
git tag -l "v1.8.5*" #search for a tag
git tag -a v1.4 -m "my version 1.4" #git tag with a version & a message
git tag v1.4 #lightweight tagging without messages
git show v1.4 #show details of 'messaged' tags
git tag v1.0 ec32d32 #or
git tag -a v1.0 ec32d32 -m 'This is the tag comment' #to add tag to existing commit
git tag -d v1.0 #to delete tags
-----------------------------------------------------------------------
git log --pretty=oneline
#generates something like this 
#15027957951b64cf874c3557a0f3547bd83b3ff6 Merge branch 'experiment'
#a6b4c97498bd301d84096da251c98a07c7723e65 beginning write support
@@@@@ press [Q] to quit from the log view
git log -n 12 #only show latest 12 commits
git log --oneline #one line [hash | Message] format
git log --stat #Details with each file 'what happend' info
git log -p  #full fucking details

-----------------------------------------------------------------------
==== RESET ====
#This usage of git reset is a simple way to undo changes that haven’t 
#been shared with anyone else.
git reset #remove changes from staging area, not from the working copy
git reset --mixed #same as above (default)
git reset --hard #remove changes from staging area AND the working copy
-----------------------------------------------------------------------
git revert HEAD~2 #or
git revert v1.4 #these creates a totally new commit with the state of given version.
-----------------------------------------------------------------------
==== BRANCHING =====
git branch #show all branches (current branch is marked!)
git checkout -b <new-branch-name> #start new branch
git checkout v1.4 -b <new-branch-name> #start a branch from a past version

git branch -d <branchname> #delete LOCAL MERGED branches
git branch -D <branchname> #delete LOCAL ANY branches
git push origin --delete <branchname> #delete REMOTE ANY branches
-----------------------------------------------------------------------
==== FILE LEVEL OPERATIONS =====
#reset-revert-checkout
https://www.atlassian.com/git/tutorials/resetting-checking-out-and-reverting/file-level-operations









