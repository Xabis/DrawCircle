DrawCircle
==========

A well rounded plugin for Doom Builder 2

![animated demo](https://raw.github.com/Xabis/DrawCircle/master/site/dc-demo.gif)

To use, simply switch to the Draw Circle mode and right-click drag to draw the guide line.

This will create a "preview" that can be edited by moving the guide handles around with your mouse, increasing or decreasing the number of linedefs, or using the panel to fine-tune the angle and radius of the circle.

When done, press Enter to create the sector.

Features
--------
* Displays on-screen measurements for each linedef, the total length across all linedefs, and the number of lines that will be created.
* Lines that are snapped to the grid are displayed in the _Selection_ color; free lines are in the _Highlighted_ color.
* __HOLD__ Shift to flip the snap state for both the circle linedefs and the guide handles. Has no effect on linedefs if the "never snap" option is enabled!
* __HOLD__ Control to flip only the linedef snapping. Has no effect at all if the "never snap" option is enabled!
* Size tools to let you resize the circle so that the linedefs all measure up to a desired length. Great for fitting textures on those columns.
* Property editor to give you fine control over the angle and length of the guide for pixel-perfect scenarios.
Note that the "Never Snap circle linedefs" option is enabled by default

NEW for 2.0:
------------
* Can now specify a "thickness" for the circle, instead of the circle always being from the point of origin.
* Can now optionally only fill in the outer circle, when thickness is used (sector will not be created for the center)
* Can now optionally draw spokes and ante spokes along the vertex and line segments, respectively.
* Control handles now always get preferential rendering
* Up/Down boxes can now be incremented/decremented by 1, 0.1, 32, by holding shift, ctrl, alt, respectively.
* Loosened sidedef requirements, so that it is possible to draw with 1 or 2 lines. This is useful for creating line guides of a specific angle and origin

![new 2.0 features](https://raw.github.com/Xabis/DrawCircle/master/site/dc-preview2.png)

2.0.1
------------
* fixed an issue where sometimes dragging a control handle would not work.
* edit mode will no longer start the drawing over by default, but will instead manipulate the control handles.
* added an auto scrollbar to the options panel for cases where the main window is not tall enough.

Shortcuts
---------
![shortcut list](https://raw.github.com/Xabis/DrawCircle/master/site/dc-keys.png)

A set of actions are available for customization inside the doom builder preferences panel. You can bind a key shortcut for easy access.

By default the +/i linedef is bound to shift + mouse wheel

You may also access these tools from the main toolbar:

![toolbar icons](https://raw.github.com/Xabis/DrawCircle/master/site/dc-toolbar.png)

Dock Panel
----------
![panel](https://raw.github.com/Xabis/DrawCircle/master/site/dc-panel.png)

A few display options are available in the side panel, as well as some handy sizing tools. To access, click the "Draw Circle" tab on the right.