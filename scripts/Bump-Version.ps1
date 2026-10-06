param(
    [Parameter(Mandatory = $true)]
    [string]$CsprojPath
)

$ErrorActionPreference = "Stop"

$xml = Get-Content $CsprojPath -Raw
if ($xml -match '<Version>(\d+)\.(\d+)\.(\d+)</Version>') {
    $major = $matches[1]
    $minor = $matches[2]
    $patch = [int]$matches[3] + 1
    $newVersion = "$major.$minor.$patch"
    $xml = $xml -replace '<Version>\d+\.\d+\.\d+</Version>', "<Version>$newVersion</Version>"
    Set-Content -Path $CsprojPath -Value $xml -NoNewline -Encoding UTF8
    Write-Host "Bumped version to $newVersion"
} else {
    Write-Warning "No <Version>X.Y.Z</Version> element found in $CsprojPath. Skipping bump."
}

$prevEAP = $ErrorActionPreference
$ErrorActionPreference = "Continue"
$lastTag = (git describe --tags --abbrev=0 2>&1 | Out-String).Trim()
$tagExitCode = $LASTEXITCODE
$ErrorActionPreference = $prevEAP

if ($tagExitCode -ne 0 -or -not $lastTag -or $lastTag -match "fatal") {
    $range = "HEAD"
} else {
    $range = "$lastTag..HEAD"
}

$prevEAP = $ErrorActionPreference
$ErrorActionPreference = "Continue"
$commits = git log $range --pretty=format:"- %s" 2>&1 | Out-String
$ErrorActionPreference = $prevEAP

if (-not $commits -or $commits.Trim() -eq "") {
    $commits = "- No new changes recorded."
}

$projectDir = Split-Path $CsprojPath
$notesPath = Join-Path $projectDir "Properties\ReleaseNotes.txt"
Set-Content -Path $notesPath -Value $commits.Trim() -Encoding UTF8

Write-Host "Release notes written to $notesPath"
Write-Host "Release date written to $releaseDatePath ($releaseTimestamp)"