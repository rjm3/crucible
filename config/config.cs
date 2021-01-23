NewActionMap("actionMap.sae");
bindAction(keyboard0, make, "tab", TO, IDACTION_MENU_PAGE, 1.000000);
bindAction(keyboard0, make, "escape", TO, IDACTION_ESCAPE_PRESSED, 0.000000);
bindAction(keyboard0, make, "k", TO, IDACTION_MENU_PAGE, 2.000000);
bindAction(keyboard0, make, "t", TO, IDACTION_CHAT, 0.000000);
bindAction(keyboard0, make, "y", TO, IDACTION_CHAT, 1.000000);
bindAction(keyboard0, make, "u", TO, IDACTION_CHAT_DISP_SIZE, -1.000000);
bindAction(keyboard0, make, "prior", TO, IDACTION_CHAT_DISP_PAGE, -1.000000);
bindAction(keyboard0, make, "next", TO, IDACTION_CHAT_DISP_PAGE, 1.000000);
bindCommand(keyboard0, make, shift, "f1", TO, "CmdInventoryGui::buyFavorites(1);");
bindCommand(keyboard0, make, shift, "f2", TO, "CmdInventoryGui::buyFavorites(2);");
bindCommand(keyboard0, make, shift, "f3", TO, "CmdInventoryGui::buyFavorites(3);");
bindCommand(keyboard0, make, shift, "f4", TO, "CmdInventoryGui::buyFavorites(4);");
bindCommand(keyboard0, make, shift, "f5", TO, "CmdInventoryGui::buyFavorites(5);");
bindCommand(keyboard0, make, "f1", TO, "remoteEval(2048, PlayMode);");
bindCommand(keyboard0, make, "f5", TO, "MEMode();");
bindCommand(keyboard0, make, "o", TO, "remoteEval(2048, ToggleObjectivesMode);");
bindCommand(keyboard0, make, "i", TO, "remoteEval(2048, ToggleInventoryMode);");
bindCommand(keyboard0, make, control, "x", TO, "commandAck();");
bindCommand(keyboard0, make, control, "d", TO, "commandDeclined();");
bindCommand(keyboard0, make, control, "c", TO, "commandCompleted();");
bindCommand(keyboard0, make, control, "y", TO, "voteYes();");
bindCommand(keyboard0, make, control, "n", TO, "voteNo();");
bindCommand(keyboard0, make, control, "e", TO, "targetClient();");
bindAction(keyboard0, make, "period", TO, IDACTION_FIRE1);
bindCommand(keyboard0, make, "f11", TO, "rpgmsghud::pageup();");
bindCommand(keyboard0, make, "f12", TO, "rpgmsghud::pagedown();");
bindCommand(keyboard0, make, "f10", TO, "rpgmsghud::resize();");
bindCommand(keyboard0, make, "q", TO, "remoteEval(2048,\"CycleEnemy\");");
bindCommand(keyboard0, make, "e", TO, "remoteEval(2048,\"CycleFriend\");");
bindCommand(keyboard0, make, "1", TO, "sendControl(\"1\");");
bindCommand(keyboard0, make, "2", TO, "sendControl(\"2\");");
bindCommand(keyboard0, make, "3", TO, "sendControl(\"3\");");
bindCommand(keyboard0, make, "4", TO, "sendControl(\"4\");");
bindCommand(keyboard0, make, "5", TO, "sendControl(\"5\");");
bindCommand(keyboard0, make, "6", TO, "sendControl(\"6\");");
bindCommand(keyboard0, make, "7", TO, "sendControl(\"7\");");
bindCommand(keyboard0, make, "8", TO, "sendControl(\"8\");");
bindCommand(keyboard0, make, "9", TO, "sendControl(\"9\");");
bindCommand(keyboard0, make, "0", TO, "sendControl(\"0\");");
bindCommand(keyboard0, make, "m", TO, "sendControl(\"m\");");
bindCommand(keyboard0, make, "n", TO, "sendControl(\"n\");");
bindCommand(keyboard0, make, "b", TO, "sendControl(\"b\");");
bindCommand(keyboard0, make, "c", TO, "sendControl(\"c\");");
bindCommand(keyboard0, make, "l", TO, "sendControl(\"l\");");
bindCommand(keyboard0, make, "h", TO, "sendControl(\"h\");");
bindCommand(keyboard0, make, "g", TO, "sendControl(\"g\");");
bindCommand(keyboard0, make, "f", TO, "sendControl(\"f\");");
bindCommand(keyboard0, make, "j", TO, "sendControl(\"j\");");
bindCommand(keyboard0, make, "]", TO, "sendControl(\"]\");");
bindCommand(keyboard0, make, "[", TO, "sendControl(\"[\");");
bindCommand(keyboard0, make, ";", TO, "sendControl(\";\");");
bindCommand(keyboard0, make, "quote", TO, "sendControl(\"'\");");
bindAction(keyboard0, make, "/", TO, IDACTION_FIRE1);
NewActionMap("playMap.sae");
bindAction(keyboard0, make, "a", TO, IDACTION_MOVELEFT, 1.000000);
bindAction(keyboard0, break, "a", TO, IDACTION_MOVELEFT, 0.000000);
bindAction(keyboard0, make, "d", TO, IDACTION_MOVERIGHT, 1.000000);
bindAction(keyboard0, break, "d", TO, IDACTION_MOVERIGHT, 0.000000);
bindAction(keyboard0, make, "s", TO, IDACTION_MOVEBACK, 1.000000);
bindAction(keyboard0, break, "s", TO, IDACTION_MOVEBACK, 0.000000);
bindAction(keyboard0, make, "w", TO, IDACTION_MOVEFORWARD, 1.000000);
bindAction(keyboard0, break, "w", TO, IDACTION_MOVEFORWARD, 0.000000);
bindAction(mouse0, make, button0, TO, IDACTION_FIRE1);
bindAction(mouse0, break, button0, TO, IDACTION_BREAK1);
bindAction(keyboard0, make, "x", TO, IDACTION_CROUCH);
bindAction(keyboard0, break, "x", TO, IDACTION_STAND);
bindAction(keyboard0, make, "e", TO, IDACTION_SNIPER_FOV, 1.000000);
bindAction(keyboard0, break, "e", TO, IDACTION_SNIPER_FOV, 0.000000);
bindAction(keyboard0, make, "z", TO, IDACTION_INC_SNIPER_FOV, 1.000000);
bindCommand(keyboard0, make, "v", TO, "setCMMode(PlayChatMenu, 2);");
bindCommand(keyboard0, make, "b", TO, "use(\"Beacon\");");
bindCommand(keyboard0, make, "m", TO, "throwStart();");
bindCommand(keyboard0, break, "m", TO, "throwRelease(\"Mine\");");
bindCommand(keyboard0, make, "g", TO, "throwStart();");
bindCommand(keyboard0, break, "g", TO, "throwRelease(\"Grenade\");");
bindCommand(keyboard0, make, "1", TO, "use(\"Blaster\");");
bindCommand(keyboard0, make, "2", TO, "use(\"Plasma Gun\");");
bindCommand(keyboard0, make, "3", TO, "use(\"Chaingun\");");
bindCommand(keyboard0, make, "4", TO, "use(\"Disc Launcher\");");
bindCommand(keyboard0, make, "5", TO, "use(\"Grenade Launcher\");");
bindCommand(keyboard0, make, "6", TO, "use(\"Laser Rifle\");");
bindCommand(keyboard0, make, "7", TO, "use(\"ELF gun\");");
bindCommand(keyboard0, make, "8", TO, "use(\"Mortar\");");
bindCommand(keyboard0, make, "9", TO, "use(\"Targeting Laser\");");
bindAction(keyboard0, make, "numpad8", TO, IDACTION_LOOKUP, 0.099989);
bindAction(keyboard0, break, "numpad8", TO, IDACTION_LOOKUP, 0.000000);
bindAction(keyboard0, make, "numpad2", TO, IDACTION_LOOKDOWN, 0.099989);
bindAction(keyboard0, break, "numpad2", TO, IDACTION_LOOKDOWN, 0.000000);
bindAction(keyboard0, make, "numpad6", TO, IDACTION_TURNRIGHT, 0.099989);
bindAction(keyboard0, break, "numpad6", TO, IDACTION_TURNRIGHT, 0.000000);
bindAction(keyboard0, make, "numpad4", TO, IDACTION_TURNLEFT, 0.099989);
bindAction(keyboard0, break, "numpad4", TO, IDACTION_TURNLEFT, 0.000000);
bindAction(keyboard0, make, "numpad5", TO, IDACTION_CENTERVIEW);
bindCommand(keyboard0, make, "h", TO, "use(\"Repair Kit\");");
bindCommand(keyboard0, make, control, "p", TO, "drop(BackPack);");
bindCommand(keyboard0, make, control, "w", TO, "drop(Weapon);");
bindCommand(keyboard0, make, control, "a", TO, "drop(Ammo);");
bindCommand(keyboard0, make, control, "f", TO, "drop(Flag);");
bindCommand(keyboard0, make, control, "k", TO, "kill();");
bindCommand(keyboard0, make, "q", TO, "nextWeapon();");
bindCommand(keyboard0, make, shift, "q", TO, "prevWeapon();");
bindCommand(keyboard0, make, "f", TO, "setFreeLook(TRUE);");
bindCommand(keyboard0, break, "f", TO, "setFreeLook(FALSE);");
bindCommand(keyboard0, make, "r", TO, "use(\"Backpack\");");
bindAction(keyboard0, make, "p", TO, IDACTION_VIEW);
bindCommand(mouse0, make, button1, TO, "remoteEval(2048,\"TargetLos\");");
bindAction(mouse0, xaxis0, TO, IDACTION_YAW, Flip, Scale, 0.001309);
bindAction(mouse0, yaxis0, TO, IDACTION_PITCH, Flip, Scale, 0.001309);
bindCommand(keyboard0, make, "space", TO, "$Plas::skiing = true;Plas::Ski(true);");
bindCommand(keyboard0, break, "space", TO, "$Plas::skiing = false;");
bindCommand(mouse0, zaxis0, TO, "nextWeapon();");
NewActionMap("pdaMap.sae");
bindAction(keyboard0, make, "z", TO, IDACTION_ZOOM_MODE_ON);
bindAction(keyboard0, break, "z", TO, IDACTION_ZOOM_MODE_OFF);
