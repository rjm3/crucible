function sendControl(%val, %mod)
{//By phantom - beatme101.com, tribesrpg.org
	remoteEval(2048,RawKey,%val, %mod);
}

exec(rpgmsghud);

EditActionMap("actionMap.sae");
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
bindCommand(keyboard0, make, "j", TO, "sendControl(\"j\");");
bindCommand(keyboard0, make, "h", TO, "sendControl(\"h\");");
bindCommand(keyboard0, make, "g", TO, "sendControl(\"g\");");
bindCommand(keyboard0, make, "f", TO, "sendControl(\"f\");");
bindCommand(keyboard0, make, "j", TO, "sendControl(\"j\");");
bindCommand(keyboard0, make, "]", TO, "sendControl(\"]\");");
bindCommand(keyboard0, make, "[", TO, "sendControl(\"[\");");
bindCommand(keyboard0, make, ";", TO, "sendControl(\";\");");
bindCommand(keyboard0, make, "'", TO, "sendControl(\"'\");");
bindAction(keyboard0, make, "/", TO, IDACTION_FIRE1);

function remoteBufferBP(%server,%new,%msg,%timeout)
{
	if (%server != 2048)
		return;
	if (%new == 1)
		$BufferPrint = %msg;
	else
		$BufferPrint = $BufferPrint @ %msg;
	if (%timeout > 0) {
		$centerPrintId++;
		schedule("clearCenterPrint(" @ $centerPrintId @ ");", %timeout);
		Client::centerPrint($BufferPrint,1);
		$BufferPrint = "";
	}
}

function remoteCruConnect(%server,%ip)
{
	if (%server != 2048)
		return;
	connect(%ip);
}

$badwords = "";