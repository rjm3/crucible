function remoteTrue()
{
	//for some reason this function gets called from key binds, so i created it so the console doesn't get flooded with
	//remoteTrue: unknown commands.
	return;
}

function remotePlayMode(%clientId)
{
	Client::clearItemShopping(%clientId);
	Client::clearItemBuying(%clientId);
	ClearCurrentShopVars(%clientId);

	if(!%clientId.guiLock)
	{
		remoteSCOM(%clientId, -1);
		Client::setGuiMode(%clientId, $GuiModePlay);
	}
}

function remoteCommandMode(%clientId)
{
	if(!(%clientId.adminLevel >= 1))
	{
		//RPG players don't need commander mode.
		return;
	}

	Client::clearItemShopping(%clientId);
	Client::clearItemBuying(%clientId);
	ClearCurrentShopVars(%clientId);

	// can't switch to command mode while a server menu is up
	if(!%clientId.guiLock)
	{
		remoteSCOM(%clientId, -1);  // force the bandwidth to be full command

		Client::setGuiMode(%clientId, $GuiModeCommand);
	}
}

function remoteInventoryMode(%clientId)
{
	Game::MenuBackpack(%clientId,0);
	//if(!%clientId.guiLock && !Observer::isObserver(%clientId))
	//{
	//	remoteSCOM(%clientId, -1);
	//	Client::setGuiMode(%clientId, $GuiModeInventory);
	//
	//	Client::clearItemShopping(%clientId);
	//	Client::clearItemBuying(%clientId);
	//
	//	%txt = "<f1><jc>COINS: " @ fetchData(%clientId, "COINS");
	//	Client::setInventoryText(%clientId, %txt);
	//}
}

function remoteObjectivesMode(%clientId)
{
	Client::clearItemShopping(%clientId);
	Client::clearItemBuying(%clientId);
	ClearCurrentShopVars(%clientId);

	if(!%clientId.guiLock)
	{
		remoteSCOM(%clientId, -1);
		Client::setGuiMode(%clientId, $GuiModeObjectives);
	}
}

function remoteScoresOn(%clientId)
{
	//================================================================================================
	if (SimSpam(%clientId.MenuSim,0.1) == True)
		return;
	%clientId.MenuSim = getSimTime();
	//================================================================================================
	if(!%clientId.menuMode) {
		Game::menuRequest(%clientId);
	}
}

function remoteScoresOff(%clientId)
{
	%clientId.tabInvo = 0;
	Client::cancelMenu(%clientId);
}

function remoteToggleCommandMode(%clientId)
{
	if(Client::getGuiMode(%clientId) != $GuiModeCommand)
		remoteCommandMode(%clientId);
	else
		remotePlayMode(%clientId);
}

function remoteToggleInventoryMode(%clientId)
{
	if(!%clientId.tabInvo) {
		Game::MenuBackpack(%clientId,0);
		%clientId.tabInvo++;
	}
	else {
		%clientId.tabInvo = 0;
		Client::cancelMenu(%clientId);
	}
	//Client::newclearItemShopping(%clientId);
	//Client::newclearItemBuying(%clientId);
	//ClearCurrentShopVars(%clientId);
	//
	//BackpackInventory(%clientId);
	//
	//if( Client::getGuiMode(%clientId) != $GuiModeInventory)
	//	remoteInventoryMode(%clientId);
	//else
	//	remotePlayMode(%clientId);
}

function remoteToggleObjectivesMode(%clientId)
{
	if(Client::getGuiMode(%clientId) != $GuiModeObjectives)
		remoteObjectivesMode(%clientId);
	else
		remotePlayMode(%clientId);
}

function remoteUseItem(%clientId, %type)
{
	dbecho($dbechoMode, "remoteUseItem(" @ %clientId @ ", " @ %type @ ")");

	%time = getIntegerTime(true) >> 5;
	if(%time - %clientId.lastWaitActionTime > $waitActionDelay)
	{
		%clientId.lastWaitActionTime = %time;

		%clientId.throwStrength = 1;

		%item = getItemData(%type);

		if(%item == Backpack) 
		{
			%item = -1;
			remoteConsider(Player::getClient(%clientId));
		}
		else
		{
			if (%item == Weapon) 
	      	      %item = Player::getMountedItem(%clientId,$WeaponSlot);
	
			if(%item != -1)
			{
				Player::useItem(%clientId, %item);
			}
		}
	}
}

function remoteThrowItem(%clientId,%type,%strength)
{
	//echo("Throw item: " @ %type @ " " @ %strength);
	%item = getItemData(%type);
	if (%item == Grenade || %item == MineAmmo) {
		if (%strength < 0)
			%strength = 0;
		else
			if (%strength > 100)
				%strength = 100;
		%clientId.throwStrength = 0.3 + 0.7 * (%strength / 100);
		Player::useItem(%clientId,%item);
	}
}

function remoteDropItem(%clientId,%type)
{
	return False;	

	//dbecho($dbechoMode, "remoteDropItem(" @ %clientId @ ", " @ %item @ ")");
	//
	//%time = getIntegerTime(true) >> 5;
	//if(%time - %clientId.lastWaitActionTime > $waitActionDelay)
	//{
	//	%clientId.lastWaitActionTime = %time;
	//
	//	if($droppingAllowed == 1)
	//	{
	//		if((Client::getOwnedObject(%clientId)).driver != 1) {
	//			//echo("Drop item: ",%type);
	//			%clientId.throwStrength = 1;
	//
	//			%item = getItemData(%type);
	//			if(%item == Weapon)
	//			{
	//				%item = Player::getMountedItem(%clientId,$WeaponSlot);
	//				Player::dropItem(%clientId,%item);
	//			}
	//			else if(%item == Ammo)
	//			{
	//				%item = Player::getMountedItem(%clientId,$WeaponSlot);
	//				if(%item.className == Weapon)
	//				{
	//					%item = %item.imageType.ammoType;
	//					Player::dropItem(%clientId,%item);
	//				}
	//			}
	//			else if (%item.className == Equipped)
	//			{
	//				Client::sendMessage(%clientId, $MsgRed, "You can't drop an equipped item!~wC_BuySell.wav");
	//			}
	//			else if ($LoreItem[%item])
	//			{
	//				Client::sendMessage(%clientId, $MsgRed, "You can't drop a lore item!~wC_BuySell.wav");
	//			}
	//			else 
	//				Player::dropItem(%clientId,%item);
	//		}
	//	}
	//}
}
function remoteDeployItem(%clientId,%type)
{
	//echo("Deploy item: ",%type);
	%item = getItemData(%type);
	Player::deployItem(%clientId,%item);
}

function remoteConsider(%clientId)
{
	dbecho($dbechoMode, "remoteConsider(" @ %clientId @ ")");

	%msgText[7] = "Easy prey!";
	%msgText[6] = "Shouldn't be a problem at all.";
	%msgText[5] = "You should win.";
	%msgText[4] = "Looks like an even fight.";
	%msgText[3] = "You might get killed...";
	%msgText[2] = "Looks VERY risky...";
	%msgText[1] = "You will NOT survive!";

	%msgColor[7] = $MsgGreen;
	%msgColor[6] = $MsgBeige;
	%msgColor[5] = $MsgBeige;
	%msgColor[4] = $MsgWhite;
	%msgColor[3] = $MsgRed;
	%msgColor[2] = $MsgRed;
	%msgColor[1] = $MsgRed;

	%maxMsg = 7;
	%midMsg = 4;
	%minMsg = 1;

	%nothingMsg = "You see nothing of interest.";
	%length = 500;
	%sawsomething = "";

	%player = Client::getOwnedObject(%clientId);
	%clientname = Client::getName(%clientId);
	%clientpos = GameBase::getPosition(%clientId);

	// CHECK FOR SHOP AREA
	//if (BackpackMerchantArea(%clientId) != False) {
	//	Client::SendMessage(%clientId,0,"You take a look at the merchants shop..");
	//	Game::menuBackpackMerchant(%clientId,0);
	//	return;
	//}

	CheckNPCZone(%clientId);


	$los::object = "";
	$los::position = "";
	if(GameBase::getLOSinfo(%player, %length))
	{
		%object = $los::object;
		%objpos = $los::position;
		%obj = getObjectType(%object);
		%cl = Player::getClient(%object);

		%index = GetEventCommandIndex(%object.tag, "onConsider");

		%name = Object::GetName(%object);

		//%item = Item::getItemData(%object);

		//echo(" NAME " @ %name);
		//echo(" OBJECT " @ %object);
		//echo(" OBJ " @ %obj);

		if (%name == "TREASURE") {
			Client::SendMessage(%clientId,2,"You attempt to open the treasure..");
			OpenTreasure(%clientId,%object);
			return;
		}

		if (string::findSubStr(%name,"MAPPORTAL") != -1) {
			Client::SendMessage(%clientId,2,"You attempt to use the map portal..");
			UseMapPortal(%clientId);
			return;
		}

		if (%item == "LootBag") {

			Client::SendMessage(%clientId,0,"You open a lootbag...");		

			%ownerName = GetWord($loot[%this], 0);
			%namelist = GetWord($loot[%this], 1);
			if($loot[%object] == "")
				%msg = "You found an empty backpack.";
		
		}


		if(%obj == "Player")
		{
			DisplayGetInfo(%clientId, %cl, %object);
			%sawsomething = True;
		}
		else if(%obj == "InteriorShape" && %object.tag != "" && %clientId.adminLevel >= 1)
		{
			Client::sendMessage(%clientId, $MsgWhite, %object @ "'s tag name: " @ %object.tag);
			%sawsomething = True;
		}
		else if(%clientId.adminLevel >= 3)
		{
			Client::sendMessage(%clientId, $MsgWhite, "Position at LOS is " @ %objpos);
			%sawsomething = True;
		}

		if(%index != -1)
		{
			%closest = 999999;
			%cindex = "";

			//pick the event with the closest radius, matching criteria of event
			for(%i2 = 0; (%index2 = GetWord(%index, %i2)) != -1; %i2++)
			{
				%ec = $EventCommand[%object.tag, %index2];

				%targetname = GetWord(%ec, 4);
				if(String::ICompare(%targetname, %clientname) == 0 || String::ICompare(%targetname, "all") == 0)
				{
					%radius = GetWord(%ec, 2);
					if(Vector::getDistance(%objpos, %clientpos) <= %radius)
					{
						if(%radius < %closest)
						{
							%closest = %radius;
							%cindex = %index2;
						}
					}
				}
			}

			if(%cindex != "")
			{
				%ec = $EventCommand[%object.tag, %cindex];

				%name = GetWord(%ec, 0);
				if((%cl = NEWgetClientByName(%name)) == -1)
					%cl = 2048;
				%keep = GetWord(%ec, 3);

				%cmd = String::NEWgetSubStr(%ec, String::findSubStr(%ec, ">")+1, 99999);
				%pcmd = ParseBlockData(%cmd, %clientId, "");
				if(!%keep)
					$EventCommand[%object.tag, %cindex] = "";
				remoteSay(%cl, 0, %pcmd, %name);

				%sawsomething = True;
			}
		}
	}

	//if(!%sawsomething)
	//	Client::sendMessage(%clientId, $MsgWhite, %nothingMsg);
}


//This function is a placeholder+prevents possible console spam.
//By phantom: beatme101.com, tribesrpg.org

function remoteRawKey(%client, %key, %mod)
{
	//echo("REMOTE RAW KEY TRIGGER: " @ %client @ " " @ %key @ " " @ %mod);

	//================================================================================================
	//if (SimSpam(%client.RawSim,0.1) == True) 
	//	return;
	//%client.RawSim = getSimTime();
	if($justRawKey[%client])
		return;
	$justRawKey[%client] = True;
	schedule("$justRawKey["@%client@"]=\"\";",0.1);
	//================================================================================================

	if (%client.NPCTalking != "") {
		NPCSelect(%client,%key);
		return;
	}

	if(%mod != "" && %mod != "control" && %mod != "alt" && %mod != "shift"){
		Client::sendMessage(%client, 0, "Erroneous modifier key.");
		return;
	}
	if(string::len(%key) > 15){
		Client::sendMessage(%client, 0, "Key name too long.");
		return;
	}
	if(String::findSubStr(%key, "\"") != -1 || String::findSubStr(%key, " ") != -1){
		client::sendmessage(%client, 0, "Invalid key.");
		return;
	}
	if(%client.isinvalid){
		client::sendmessage(%client, 0, "You have no character loaded yet!");
		return;
	}
	if(%client.overrideKeybinds){		
		remoteRawOverride(%client, %key, %mod);		
		return;	
	}
	if($numMessage[%client, %key] == ""){
		Client::sendMessage(%client, 0, "Key: " @ %key @ " is not bound to anything.");
	}
	else{
		UseKeyBind(%client,%key);
		//client::SendMessage(%client,0,$numMessage[%client, %key]);
	}
}