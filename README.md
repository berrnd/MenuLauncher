# MenuLauncher
Little app to launch programs through a tiny (context) menu strip, excellent for placing it in a taskbar toolbar

![Screenshot](/publication_assets/screenshot1.png?raw=true "Screenshot")

# How to use
Just download the [latest release](https://github.com/berrnd/MenuLauncher/releases/latest), place it wherever you like and create a shortcut to `MenuLauncher.exe` with at least one parameter - the folder where your shortcuts are in.

## Available parameters
```MenuLauncher.exe <FolderPath> [--no-icons] [--add-info-before=SomeText] [--add-info-below=SomeText] [--hide-left=N]```

`FolderPath` is path to folder with shortcuts/elements to populate the menu from

`--no-icons` Don't show icons in the menu

`--add-info-before` Add some insensitive items on top of the menu

`--add-info-below` Add some insensitive items at the bottom of the menu

`--hide-left` Hide left `N` characters of every menu entry, useful if you use numbers for sorting

## Other notes
- Files containing only `-` characters (excluding file extension and left `N` characters defined in `--hide-left`) are replaced with separators in the menu

- If shift is pressed on application start, the folder given in `FolderPath` will be opened instead of the menu shown

# License
The MIT License (MIT)
