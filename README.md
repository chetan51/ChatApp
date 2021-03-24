# ChatApp

Simple chat app prototype

# Tradeoffs

- Due to time constraints, decided to use synchronous calls to DataManager to simulate fetching data from backend. For a more realistic simulation of fetching data from backend, those calls should be asynchronous.
 
# Follow Ups
- [ ] Refactor DataManager to use async calls instead, to better simulate calls over the network
- [ ] Animate transitions between screens
- [ ] Clean up / remove the need to rebuild layout over 3 frames when loading message list