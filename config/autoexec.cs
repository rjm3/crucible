$WSWidth = "1920";
$WSHeight = "1080";
$pref::PlayerFov = 90;
exec(rpggui);
exec(rpgCrucible);
exec(Plasmatic_Ski);

seedRandomMT(0);
function testMT(%a)
{
	echo("------------------------------------------------------------------------------------");
	%t = 0;
	for (%i = 0; %i <= %a; %i++) {
		%r = floor(getRandomMT() * 100 + 1);
		%z[%r]++;
		if (%r <= 15) %k[15]++;
		if (%r >= 16 && %r <= 30) %k[30]++;
		if (%r >= 31 && %r <= 45) %k[45]++;
		if (%r >= 46 && %r <= 60) %k[60]++;
		if (%r >= 61 && %r <= 75) %k[75]++;
		if (%r >= 76 && %r <= 90) %k[90]++;
		if (%r > 91) %k[100]++;
	}
	for (%i = 0; %i <= 100; %i++) {
		echo(%i @ " " @ %z[%i] @ " %" @ ((%z[%i] / %a) * 100));	
	}
	echo("------------------------------------------------------------------------------------");
	echo(" 15 " @ floor((%k[15] / %a) * 100));
	echo(" 30 " @ floor((%k[30] / %a) * 100));
	echo(" 45 " @ floor((%k[45] / %a) * 100));
	echo(" 60 " @ floor((%k[60] / %a) * 100));
	echo(" 75 " @ floor((%k[75] / %a) * 100));
	echo(" 90 " @ floor((%k[90] / %a) * 100));
	echo(" 100 " @ floor((%k[100] / %a) * 100));
}

$TPOSON = 1;
function OnClientMessage(%a,%b)
{
	if ((%find = string::findSubSTr(%b,"Position at LOS is")) != -1) {
		%x = getWord(%b,4);
		%y = getWord(%b,5);
		%z = getWord(%b,6);
		%on = $TPOSON;
		$TPOS[%on] = %x @ " " @ %y @ " " @ %z;
		$TPOSON++;
	}
}