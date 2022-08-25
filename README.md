# ⚔️ GladiApi

A C# library for interacting with the browser-based idle game *Gladiatus* from *Gameforge*. There is no browser automation - all character actions use requests, however retrieval of game information is done by evaluating document get requests and therefore the game's html.

## GladiApi

The actual api source

### Instantiation

Since this api is request based and initialization data has to be fetched, most classes use an async factory pattern for instantiation. That means you will not create a class instance the classic way (with the `new` keyword) but instead with the static `CreateInstanceAsync` method, which has to be `await`ed.

## GladiApiConsole

User interface to test the library

## Api Doc

---
