// PluginLoader Info:
// -----------------------------------------------------------------------------
// CommandLine Forced Load or No-Load < Over-rides Script-Based Load  >
// -----------------------------------------------------------------------------
// Forced Load Example: Tribes.exe +p DoSFix
// Forced No-Load Example: Tribes.exe -p DoSFix
// Multiple Plugin Example: Tribes.exe +p DoSFix,crcBypass,etc.
// -----------------------------------------------------------------------------
// Script-Based Load
// Example: $PluginLoader::DoSFix = true;
// -----------------------------------------------------------------------------
$PluginLoader::DoSFix = false;
$PluginLoader::MathPlugin = true;
$PluginLoader::StringPlugin = true;
$PluginLoader::GraphicPlugin = true;
$PluginLoader::PatchesPlugin = false; //Disabling for now.  Fixes export by default and allows to set terrain collision detection if enabled
$PluginLoader::CommLinkPlugin = true;
$PluginLoader::ClientSideAddonPlugin = true;
$PluginLoader::ServerSidePlugin = true;
$PluginLoader::BovExpansionPlugin = true;
//$PluginLoader::Attachment = false;
//$PluginLoader::TerrainInfo = true;
//$PluginLoader::Extras = true;