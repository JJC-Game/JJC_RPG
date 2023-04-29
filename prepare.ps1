$shellPath = Get-Location
$scriptsDirPath = Join-Path $shellPath "\Assets\Scripts"
$resourcesDirPath = Join-Path $shellPath "\Assets\Resources"
$projectAssetsDirPath = Join-Path $resourcesDirPath "\ProjectAssets"

if( Test-Path $scriptsDirPath ){

}else{
    New-Item $scriptsDirPath -ItemType Directory
}

if( Test-Path $resourcesDirPath ){

}else{
    New-Item $resourcesDirPath -ItemType Directory
}

if( Test-Path $projectAssetsDirPath ){

}else{
    New-Item $projectAssetsDirPath -ItemType Directory
}
