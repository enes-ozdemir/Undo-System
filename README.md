## What I built
* It's an undo system implementation for Solitaire, implemented using the Command Design Pattern.
* Each card movement is encapsulated as a command, making it easy to undo the player's last move.

## What you’d improve with more time,
* Implement customized cards with a card customizer tool.
* Refactor the undo system to use the Observer Pattern for code to be more decoupled.
* Serialize custom values to control them through the Unity Inspector.

## Which parts were AI-assisted, and how you prompted/used it
* The initial code implementation for the system was generated with the help of AI. However, the AI-generated code needed strong manual control, as AI tends to favor popular but poorly performing practices (e.g., using FindObjectByTag, FindObjectByType).
* Additionally, the AI was not successful in properly handling validations between systems, which required manual corrections to ensure correct system interactions.
