# ⚔️ GladiatusApi

A C# library for interacting with the browser-based idle game *Gladiatus* from *Gameforge*. There is no browser automation - all character actions use ajax requests, however retrieval of game information is done by evaluating document GET requests and therefore requires parsing the game's html.

```diff
- Please note that using this to actually automate the game break's Gladiatus TOS! -
```

## GladiApi

The actual api source. Wip.

### Instantiation

Since this api is request based and initialization data has to be fetched, most classes use an async factory pattern for instantiation. That means you will not create a class instance the classic way (with the `new` keyword) but instead with the static `CreateInstanceAsync` method, which has to be `await`ed.

## GladiApiConsole

User interface to test the library

## Api Doc

Coming after Version 0.1
---

## Version

*Indev 0.0*
