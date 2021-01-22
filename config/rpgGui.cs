$RPGGui::FHH_Names[0] = "FightingHudHealth_Gray";
$RPGGui::FHH_Names[1] = "FightingHudHealth_G0";
$RPGGui::FHH_Names[2] = "FightingHudHealth_G1";
$RPGGui::FHH_Names[3] = "FightingHudHealth_G2";
$RPGGui::FHH_Names[4] = "FightingHudHealth_Y0";
$RPGGui::FHH_Names[5] = "FightingHudHealth_Y1";
$RPGGui::FHH_Names[6] = "FightingHudHealth_Y2";
$RPGGui::FHH_Names[7] = "FightingHudHealth_R0";
$RPGGui::FHH_Names[8] = "FightingHudHealth_R1";
$RPGGui::FHH_Names[9] = "FightingHudHealth_R2";

$RPGGui::AMR_Id[0] = 0;
$RPGGui::AMR_Name[0] = "ActionBar";
$RPGGui::AMR_Id[1] = 0;
$RPGGui::AMR_Name[1] = "SpellBar";

function buildmm()
{
	$mmhud = newObject("rpgmm", FearGuiFormattedText, 500, 50, 100, 100);
	control::setValue("rpgmm","<jc>Testing<n>Testing<n>Testing");
	addToSet(PlayGui, $mmhud);
}

//Call this from the OnExit before the play.gui is saved
function RPGGui::Hide() {
	Control::setvisible("FndFightingHud", false);
	Control::setVisible("OppFightingHud", false);

	Control::setVisible($RPGGui::AMR_Name[0] @ "_Parent", false);
	Control::setVisible($RPGGui::AMR_Name[1] @ "_Parent", false);
	Control::setVisible("TeamRPGHud", false);
}

function remoteRPGGui::EnableTeam(%server)
{
	if (%server != 2048)
		return;
	Control::setVisible("TeamRPGHud", true);
}

function remoteRPGGui::DisableTeam(%server)
{
	if (%server != 2048)
		return;
	Control::setVisible("TeamRPGHud", false);
}

function remoteRPGGui::EnableTarget(%server)
{
	if (%server != 2048)
		return;
	Control::setVisible("OppFightingHud", true);
}

function remoteRPGGui::DisableTarget(%server)
{
	if (%server != 2048)
		return;
	Control::setVisible("OppFightingHud", false);
}

function remoteRPGGui::EnableFriend(%server)
{
	if (%server != 2048)
		return;
	Control::setVisible("FndFightingHud", true);
}

function remoteRPGGui::DisableFriend(%server)
{
	if (%server != 2048)
		return;
	Control::setVisible("FndFightingHud", false);
}


function TestEnableRPGHud()
{
	Control::setvisible("FndFightingHud", true);
	Control::setVisible("OppFightingHud", true);

	Control::setVisible($RPGGui::AMR_Name[0] @ "_Parent", true);
	Control::setVisible($RPGGui::AMR_Name[1] @ "_Parent", true);
	Control::setVisible($RPGGui::AMR_Name[0], false);
	Control::setVisible($RPGGui::AMR_Name[1], false);
	Control::setVisible("TeamRPGHud", true);
}

function remoteRPGGui::Hud(%server) {
	if(%server != 2048)
		return;

	Control::setvisible("FndFightingHud", true);
	Control::setVisible("OppFightingHud", true);

	Control::setVisible($RPGGui::AMR_Name[0] @ "_Parent", true);
	Control::setVisible($RPGGui::AMR_Name[1] @ "_Parent", true);
	Control::setVisible($RPGGui::AMR_Name[0], false);
	Control::setVisible($RPGGui::AMR_Name[1], false);
	Control::setVisible("TeamRPGHud", true);
}

//<jc><f2>[name] for %mine
//<jc><f1>[name] for %opponents to get colors right
function remoteRPGGui::FndFightingNames(%server, %mine, %opponents) {
	if(%server != 2048)
		return;

	Control::setValue("FightingHudFndName", %mine);
	Control::setValue("FightingHudOppName", %opponents);
}

//Accepted values between 0 and 1
function remoteRPGGui::FndFightingHealth(%server, %clrId, %value) {
	if(%server != 2048)
		return;

	%clrId = floor(%clrId);
	for(%i=0; %i<10; %i++) {
		Control::setVisible($RPGGui::FHH_Names[%i], false);
	}
	Control::setVisible($RPGGui::FHH_Names[%clrId], true);

	Control::setValue($RPGGui::FHH_Names[%clrId], %value);
}

//<jc><f2>[name] for %mine
//<jc><f1>[name] for %opponents to get colors right
function remoteRPGGui::OppFightingNames(%server, %mine, %opponents, %mm) {
	if(%server != 2048)
		return;
	Control::setValue("OppFightingHudFndName", %mine);
	Control::setValue("OppFightingHudOppName", %opponents);
	Control::setValue("rpgmm", %mm);
}

//Accepted values between 0 and 1
function remoteRPGGui::OppFightingHealth(%server, %clrId, %value) {
	if(%server != 2048)
		return;

	%clrId = floor(%clrId);
	for(%i=0; %i<10; %i++) {
		Control::setVisible("Opp" @ $RPGGui::FHH_Names[%i], false);
	}
	Control::setVisible("Opp" @ $RPGGui::FHH_Names[%clrId], true);

	Control::setValue("Opp" @ $RPGGui::FHH_Names[%clrId], %value);
}

//%id between 0 and 5
function remoteRPGGui::UpdateTeamName(%server, %id, %name) {
	if(%server != 2048)
		return;

	if(%name == "") {
		Control::setVisible("_" @ %id @ "_Teammate", false);
		Control::setVisible("_" @ %id @ "_Health_G", false);
		Control::setVisible("_" @ %id @ "_Health_R", false);
		Control::setVisible("_" @ %id @ "_mana", false);
		return;
	}
	Control::setVisible("_" @ %id @ "_Teammate", true);
	Control::setVisible("_" @ %id @ "_TeamName", true);
	Control::setValue("_" @ %id @ "_TeamName", %name);
}

function remoteRPGGui::UpdateTeamMana(%server, %id, %value) {
	if(%server != 2048)
		return;

	if(%value < 0) {
		Control::setVisible("_" @ %id @ "_mana", false);
		return;
	}

	Control::setVisible("_" @ %id @ "_mana", true);
	Control::setValue("_" @ %id @ "_mana", %value);
}

function remoteRPGGui::UpdateTeamHealth(%server, %id, %value) {
	if(%server != 2048)
		return;

	if(%value < 0) {
		Control::setVisible("_" @ %id @ "_Health_G", false);
		Control::setVisible("_" @ %id @ "_Health_R", false);
		return;
	}

	if(%value > 0.25) {
		Control::setVisible("_" @ %id @ "_Health_G", true);
		Control::setVisible("_" @ %id @ "_Health_R", false);
		Control::setValue("_" @ %id @ "_Health_G", %value);
	}
	else {
		Control::setVisible("_" @ %id @ "_Health_G", false);
		Control::setVisible("_" @ %id @ "_Health_R", true);
		Control::setValue("_" @ %id @ "_Health_R", %value);
	}
}

function remoteRPGGui::ActionRefresh(%server, %timeLeft, %recharge, %text) {
	if(%server != 2048)
		return;
	Control::setVisible($RPGGui::AMR_Name[0] @ "_Parent", true);

	Control::SetValue($RPGGui::AMR_Name[0]@"Label", %text);
	$RPGGui::AMR_Id[0] = ($RPGGui::AMR_Id[0] + 1)%256; //Keep looping between 0 and 255
	if(%recharge)
		RPGGui::updateBar(Floor(%timeLeft*10)/10, Floor(%timeLeft*10)/10,$RPGGui::AMR_Id[0], 0, 1);
	else
		RPGGui::updateBar(Floor(%timeLeft*10)/10, Floor(%timeLeft*10)/10,$RPGGui::AMR_Id[0], 0, -1);
}

function remoteRPGGui::SpellRefresh(%server, %timeLeft, %recharge, %text) {
	if(%server != 2048)
		return;
	Control::setVisible($RPGGui::AMR_Name[1] @ "_Parent", true);

	Control::SetValue($RPGGui::AMR_Name[1]@"Label", "<f2>"@%text);
	$RPGGui::AMR_Id[1] = ($RPGGui::AMR_Id[1] + 1)%256; //Keep looping between 0 and 255
	if(%recharge)
		RPGGui::updateBar(Floor(%timeLeft*10)/10, Floor(%timeLeft*10)/10,$RPGGui::AMR_Id[1], 1, 1);
	else
		RPGGui::updateBar(Floor(%timeLeft*10)/10, Floor(%timeLeft*10)/10,$RPGGui::AMR_Id[1], 1, -1);
}

//This will show a bar slowly decreasing in %timeLeft
function RPGGui::updateBar(%startTime, %timeLeft, %id, %type, %direction) {
	if(%id != $RPGGui::AMR_Id[%type]) //Check Id before changing anything
		return;

	if(%timeLeft < 0) {
		Control::setVisible($RPGGui::AMR_Name[%type], false);
		Control::setVisible($RPGGui::AMR_Name[%type] @ "Label", false);
		return;
	}

	Control::setVisible($RPGGui::AMR_Name[%type], true);
	Control::setVisible($RPGGui::AMR_Name[%type] @ "Label", true);
	if(%direction > 0)
		Control::setValue($RPGGui::AMR_Name[%type], 1 - %timeLeft/%startTime);
	else
		Control::setValue($RPGGui::AMR_Name[%type], %timeLeft/%startTime);

	%timeLeft -= 0.1;

	schedule("RPGGui::updateBar("@%startTime@", "@%timeLeft@", "@%id@", "@%type@", "@%direction@");", 0.1); //No saftey concern as the remotes filter out exploits
}