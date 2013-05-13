﻿Installation and Configuration
====================

\section installation_requirements Requirements 

The Directoutput framework relies on the B2S-Server which has been developed by Herweh/Stefan. The B2S-Server implements a plugin interface which can load and execute plugins. This framework has been developed as such a plugin.

Therefore you must first install and configure Herwehs B2S-Server before you can install the DirectOutput framework. You can download the B2S-Server from <a href="www.vpforums.org">VPForums</a>.

\section installation_installation Download 

The DirectOutput framework can be found on GitHub. Please check the project page for the latest version of the framework.

You are also very welcome to fork/download and enhance the source code from GitHub.


\section installation_installation Installation 

Unzip the contents of the zip-file containing the framework to the following subpath of the B2S-Server: {B2S-Server directory}\Plugin\DirectOutput

The B2S-Server will automatically detect the framework on startup and integrate it. Please check <a href="http://www.vpforums.org/index.php?showforum=86">VPForums</a> for more information on the B2S-Server.

Alternatively the DirectOutput framework can also be put into any other directory on your system and a windows shortcut point to this directory can be added to the {B2S-Server directory}\Plugin directory. The B2S.Server will follow this shortcut to your plugin directory.


\section installation_configuration Configuration 

\subsection installation_visualpinballtableconfig Visual Pinball Table Config
Tables using the DirectOutput framework resp. the B2S-Server have to instanciate the B2S.Server instead of the Pinmame.Controller.

Replace the following line in the table scripts of the tables you want to use the DirectOutput framework:

~~~~~~~~~~~~~~~{.vbs}
Set Controller = CreateObject("VPinMAME.Controller")     
~~~~~~~~~~~~~~~

with

~~~~~~~~~~~~~~~{.vbs}
Set Controller = CreateObject("B2S.Server") 
~~~~~~~~~~~~~~~

\subsection installation_visualpinballcorevbs Visual Pinball core.vbs Adjustment

If you have used the <a href="http://www.hyperspin-fe.com/forum/showthread.php?10980-Tutorial-How-to-config-Ledwiz-PacDrive">VBScript solution</a> to control your LedWiz you will have to _remove_ the following line from your core.vbs:

~~~~~~~~~~~~~~~{.vbs}
ExecuteGlobal GetTextFile("ledcontrol.vbs")
~~~~~~~~~~~~~~~

Otherwise you'll likely run into trouble since both solutions will run simultaneously!

\subsection installation_globalconfig Global Configuration

The global configuration specifies some global settings for the framework, like the places where cabinet and table configurations are looked up.

Please read the page on Global Configuration for a detail explanation of the settings.

\subsection installation_cabinetconfig Cabinet Configuration

The cabinet configuration specifies the output controllers (e.g. Ledwiz) and toys (e.g. contactors and RGB leds) in your cabinet.

Please read the page on Cabinet Configuration for more information.

\subsection installation_tableconfig Table Configuration

The table configuration specifies the elements on a pinball table (e.g. solenoids or lamps) and the effects assigned to the table elements.
  
Please read the page on Table Configuration for details.

\subsection installation_ledcontrolini LedControl.ini files

The DirectOutput framework can use one or several classical LedControl.ini files to automatical configure tables and cabinets.

Please refer to the page LedControl Files for details.