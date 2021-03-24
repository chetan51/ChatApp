# ChatApp

Simple chat app prototype

# Tradeoffs

- I used https://next.json-generator.com/Eko-yNmE5 to generate the sample data. Since the generator doesn't support generating more than 100 elements within a list, each conversation has a total of 100 messages, and the message list loads 40 at a time.
- Due to time constraints, I decided to use synchronous calls to DataManager to simulate fetching data from backend. For a more realistic simulation of fetching data from backend, those calls should be asynchronous.
- Due to time constraints, I skipped implementing loading of profile photos from photo URLs. If you'd prefer that I implement this feature for completeness, please let me know and I'll be happy to take a bit more time to do so.
- I designed the data model for Conversations to have a list of Persons who are participating in the Conversation, with the first Person always being the user's friend, and the second person being the user themselves.
  - Each Message has a Person Index referring to the Person in the Conversation who sent that Message.
  - I did this for simplicity and speed of implementation. Alternately, we could assign a unique ID to each person, reference the Person in the Message by ID, and fetch Persons by ID when loading the message list (ensuring we cache loaded Persons so that we don't duplicate requests.)
- I kept comments to a minimum for speed of implementation. I would add more comments for additional clarity.
 
# Follow Ups
- [ ] Implement loading of profile photos from photo URLs (maintaining a LRU cache of loaded photos to avoid duplicate requests)
- [ ] Refactor DataManager to use async calls instead, to better simulate calls over the network
- [ ] Animate transitions between screens
- [ ] Clean up / remove the need to rebuild layout over 3 frames when loading message list
- [ ] Use object pooling when spawning UI elements for improved performance
