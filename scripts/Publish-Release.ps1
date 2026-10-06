param(
    [Parameter(Mandatory = $true)]
    [string]$Version,

    [string]$SourceFolder = "",
    [string]$OutputZip = "",
    [string]$Repo = "reyesjosel/StockRoom11net030826",
    [int]$MaxRetries = 5,
    [int]$RetryDelaySeconds = 3
)

$ErrorActionPreference = "Stop"

$ScriptDir = Split-Path -Parent $PSCommandPath
$RepoRoot = Split-Path -Parent $ScriptDir

if ([string]::IsNullOrWhiteSpace($SourceFolder)) {
    $SourceFolder = Join-Path $RepoRoot "bin\Release\net11.0-windows\win-x64\folder.publish"
}
if ([string]::IsNullOrWhiteSpace($OutputZip)) {
    $OutputZip = Join-Path $ScriptDir "StockRoom11net-$Version.zip"
}

if (-not (Get-Command gh -ErrorAction SilentlyContinue)) {
    Write-Warning "GitHub CLI ('gh') not found on PATH. Install with: winget install --id GitHub.cli"
    Write-Warning "Skipping GitHub release creation."
    exit 0
}

# Wait/retry in case ClickOnce is still writing files when this fires
$found = $false
for ($i = 1; $i -le $MaxRetries; $i++) {
    if (Test-Path $SourceFolder) {
        $files = Get-ChildItem $SourceFolder -Recurse -File -ErrorAction SilentlyContinue
        if ($files -and $files.Count -gt 0) { $found = $true; break }
    }
    Write-Warning "Attempt ${i}/${MaxRetries}: '$SourceFolder' not ready yet. Retrying in $RetryDelaySeconds s..."
    Start-Sleep -Seconds $RetryDelaySeconds
}

if (-not $found) {
    Write-Warning "Source folder not found or empty after $MaxRetries attempts: $SourceFolder. Skipping release."
    exit 0
}

# Write the true release timestamp directly into the publish output, guaranteeing accuracy
# regardless of MSBuild content-copy timing during Build/Publish.
$releaseTimestamp = Get-Date -Format "yyyy-MM-dd HH:mm:ss"
$publishPropertiesDir = Join-Path $SourceFolder "Properties"
if (-not (Test-Path $publishPropertiesDir)) {
    New-Item -ItemType Directory -Path $publishPropertiesDir -Force | Out-Null
}
Set-Content -Path (Join-Path $publishPropertiesDir "ReleaseDate.txt") -Value $releaseTimestamp -Encoding UTF8
Write-Host "Release date stamped in publish output: $releaseTimestamp"

Write-Host "Zipping '$SourceFolder' -> '$OutputZip'..."
if (Test-Path $OutputZip) { Remove-Item $OutputZip -Force }
Compress-Archive -Path "$SourceFolder\*" -DestinationPath $OutputZip -Force

# Ensure tag exists locally + remotely, tolerating "already exists"
$localTag = git tag --list $Version
if (-not $localTag) {
    git tag $Version
}

$prevEAP = $ErrorActionPreference
$ErrorActionPreference = "Continue"
$pushResult = git push origin $Version 2>&1 | Out-String
$pushExitCode = $LASTEXITCODE
$ErrorActionPreference = $prevEAP

if ($pushExitCode -ne 0 -and $pushResult -notmatch "already exists") {
    Write-Warning "git push failed: $pushResult"
} else {
    Write-Host $pushResult
}

$prevEAP = $ErrorActionPreference
$ErrorActionPreference = "Continue"

$null = gh release view $Version --repo $Repo 2>&1
$viewExitCode = $LASTEXITCODE

if ($viewExitCode -eq 0) {
    Write-Host "Release $Version already exists, uploading/overwriting asset..."
    gh release upload $Version $OutputZip --repo $Repo --clobber 2>&1 | Out-String | Write-Host
} else {
    Write-Host "Creating GitHub release $Version with asset..."
    $notesFile = Join-Path $RepoRoot "Properties\ReleaseNotes.txt"
    if (Test-Path $notesFile) {
        gh release create $Version $OutputZip --repo $Repo --title "Release $Version" --notes-file "$notesFile" 2>&1 | Out-String | Write-Host
    } else {
        gh release create $Version $OutputZip --repo $Repo --title "Release $Version" --generate-notes 2>&1 | Out-String | Write-Host
    }
}

$ErrorActionPreference = $prevEAP

Write-Host "Done. Release published: https://github.com/$Repo/releases/tag/$Version"