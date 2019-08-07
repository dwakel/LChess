# LChess
Voice Controlled Chess Game

This Chess game is a voice controlled 2 Player chess game. It still provides the generic mouse click and select method to move ches pieces

# Project Summary
The chess board and game i designed purely using WPF and no game engine of any sort. Speech recognition is implemented using
Microsoft Speech Recognition library for WPF. The Chess board is a 2 dimentional array or Matrix label using a combination of
Alphabets and numbers (eg. A1 represets the first position of the board, usualy where the Rook will be position at the start of the game for one player)

Each position on the board is an object with the position name, this is used to identify every position on the chess board. This is also what is used to 
move a piece from location on the board to another according the constraints of that chess piece.

To move a chess piece, you click all speak (into your microphone) the name of the location where the chess piece is placed. Positions on
the board which are valid moves for your piece will be highlighted in green, and potentions "kills" will be highlighted in red. You move to the specific location
on the board by clicking on the valid move postion or speaking `move to` + name of the board location to move to.

# Game grammar
This is a list of voic commands to play the game

- Board
To call upon pieces on the board a combination of Alphabets and numbers
  Valid Aphabets: A, B, C ,D ,E ,F, G, H
  Valid Numbers: 1, 2, 3, 4, 5, 6, 7, 8
  
  Format for call:
  Alphabet + Number
  eg. A6, B8, H3
  calling upon the piece selects it for you to view if it is valid. The implementation works such that a piece is called before you can make any
  movement commands. Even if you know that a move is valid you cannot skip this step.
  
 After a piece is selected, Movement to valid locations are done by using the phrase `move to`.
 Eg. `move to` `H3`
 
 - Promotion
  When a pawn is able to reach he other side of the board for the second play immediate the promotion feature is unlocked. You can promot that piece to a Queen, Rook, Knight or, Bishop
  this is done by speaking
  
  `promote to` + [Queen | Knight | bishop | rook]

To reset the game simple speak into your microphone: `reset board`
 
  
  
