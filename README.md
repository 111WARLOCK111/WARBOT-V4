WARBOT-V4
=========

WARBOT V4 Is an advanced IRC bot, With features of Talking, Learning from peoples and running lua codes.
It also can be used as an IRC Client. Tested on esper irc, Works with non-colored text messages and some game IRC Bots such as fCraft or MCForge IRC Bots.


How to use
==========

It's pretty simple, At start it asks you for channel, username, host and password. To send someone or a channel a message, Use the following way:
```
#Channelhere Message
```

If you want to save the temp database (Talking database), Use the following action from console:
```
save
```


Requirements
============

Windows OS With NET Framework 4+.
NOTE: Linux OS or Ubuntu wouldn't work with this bot due to not supporting C++ Libs on mono, If you're a mono user remove the lua parts from codes.


How to talk
===========

WARBOT V4 Is a question answering bot (Mostly), Ask your questions by starting them with What or Who, If you want to teach the bot a message,
Your message must contain Is on it, Examples:

```lua
-- Telling the bot
User: Google is a great search engine
User: Lua scripting is supported on WARBOT
User: Our database is flatfile
User: All the talking messages i send is on templist of WARBOT
-- Asking the bot
User: What is google?
Bot: Google is a great search engine
User: What is our database?
Bot: Our database is flatfile
User: What is send?
Bot: All the talking messages i send is on templist of WARBOT
User: Who is google?
Bot: Google is a great search engine
```


Lua Scripting
=============

You got two ways to do some lua scripts, First way is on channel (Public view)
For public lua codes (In channel) codes, run this following code from another client/webclient:
```lua
lua::Join("#channelname")
```

If you want to send codes privately, PM the code to bot, like this:
```lua
Quit("#channelname")
```
