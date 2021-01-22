$ConsoleWorld::DefaultSearchPath = ".;base\\scripts;base\\missions;base";

// load the base volumes
if(isFile("base\\darkstar.vol"))
	newObject( DarkstarVol, SimVolume, "base\\darkstar.vol" );
if(isFile( "base\\common.vol" ))
	newObject( CommonVol, SimVolume, "base\\common.vol" );
if(isFile( "base\\scripts.vol"))
   newObject( ScriptsVol, SimVolume, "base\\scripts.vol" );
if(isFile( "base\\entities.vol"))
   newObject( EntitiesVol, SimVolume, "base\\entities.vol" );
   
newObject( town_jungle, SimVolume, "crurpg\\town_jungle.vol" );
newObject( town_jmarket, SimVolume, "crurpg\\town_jmarket.vol" );
newObject( c, SimVolume, "crurpg\\jbank.vol" );
newObject( d, SimVolume, "crurpg\\jmountain1.vol" );
newObject( e, SimVolume, "crurpg\\jmountain4.vol" );
newObject( f, SimVolume, "crurpg\\jstones.vol" );
newObject( underwell, SimVolume, "crurpg\\underwell.vol" );
newObject( h, SimVolume, "crurpg\\floodcav.vol" );
newObject( i, SimVolume, "crurpg\\losttemple.vol" );
newObject( j, SimVolume, "crurpg\\losttemple2.vol" );
newObject( k, SimVolume, "crurpg\\losttemple3.vol" );
newObject( l, SimVolume, "crurpg\\fwaterway.vol" );
newObject( m, SimVolume, "crurpg\\emeraldmine.vol" );
newObject( n, SimVolume, "crurpg\\undertree.vol" );
newObject( o, SimVolume, "crurpg\\underwell_ent.vol" );
newObject( p, SimVolume, "crurpg\\tribalflood.vol" );
newObject( q, SimVolume, "crurpg\\jcave_ent.vol" );
newObject( r, SimVolume, "crurpg\\cfirepit1.vol" );
newObject( s, SimVolume, "crurpg\\emeraldmine_ent.vol" );

newObject(serverDelegate, FearCSDelegate, true, "LOOPBACK", $Server::Port);

// load up all the dynamic data stuff
exec(admin);
exec(Marker);
exec(Trigger);
exec(NSound);
exec(BaseExpData);
exec(BaseDebrisData);
exec(BaseProjData);
exec(ArmorData);
exec(Mission);
exec(Item);
exec(Player);
exec(Vehicle);
exec(Turret);
exec(Beacon);
exec(StaticShape);
exec(Station);
exec(Moveable);
exec(Sensor);
exec(Mine);
exec(AI);
exec(InteriorLight);
preloadServerDataBlocks();
focusServer();
