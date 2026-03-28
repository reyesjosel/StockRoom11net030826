<#
.SYNOPSIS
    Removes large video file from Git history using BFG Repo-Cleaner
.DESCRIPTION
    This script removes DestinyZeroHour.mp4 (58 MB) from Git history completely
    using BFG Repo-Cleaner. It will rewrite Git history and force push to GitHub.
.NOTES
    Author: GitHub Copilot
    Date: March 28, 2026
    Repository: StockRoom11net030826
    WARNING: This rewrites Git history. Backup is created automatically.
#>

# Set error action preference
$ErrorActionPreference = "Stop"

# Configuration
$repoPath = "C:\Users\reyes\Source\Repos\StockRoom11net030826"
$reposParentPath = "C:\Users\reyes\Source\Repos"
$toolsPath = "C:\Tools"
$bfgJarPath = "$toolsPath\bfg.jar"
$bfgUrl = "https://repo1.maven.org/maven2/com/madgag/bfg/1.14.0/bfg-1.14.0.jar"
$fileToRemove = "DestinyZeroHour.mp4"
$backupPath = "$reposParentPath\StockRoom11net030826_BACKUP_$(Get-Date -Format 'yyyyMMdd_HHmmss')"
$mirrorPath = "$reposParentPath\StockRoom11net030826-mirror.git"

# Helper function for colored output
function Write-Step {
    param([string]$Message, [string]$Color = "Cyan")
    Write-Host "`n=== $Message ===" -ForegroundColor $Color
}

function Write-Success {
    param([string]$Message)
    Write-Host "✓ $Message" -ForegroundColor Green
}

function Write-Error-Custom {
    param([string]$Message)
    Write-Host "✗ $Message" -ForegroundColor Red
}

function Write-Warning-Custom {
    param([string]$Message)
    Write-Host "⚠ $Message" -ForegroundColor Yellow
}

# Main script
try {
    Write-Host @"
╔══════════════════════════════════════════════════════════════╗
║  BFG Repo-Cleaner: Remove Large File from Git History        ║
║  File: $fileToRemove (58 MB)                                 ║
╚══════════════════════════════════════════════════════════════╝
"@ -ForegroundColor Cyan

    # Step 1: Check Java installation
    Write-Step "Step 1: Checking Java installation"
    try {
        $javaVersion = java -version 2>&1 | Select-Object -First 1
        Write-Success "Java is installed: $javaVersion"
    }
    catch {
        Write-Error-Custom "Java is not installed!"
        Write-Host "Please install Java from: https://www.java.com/download/" -ForegroundColor Yellow
        Write-Host "After installing Java, run this script again." -ForegroundColor Yellow
        exit 1
    }

    # Step 2: Download BFG if needed
    Write-Step "Step 2: Downloading BFG Repo-Cleaner"
    if (-not (Test-Path $toolsPath)) {
        New-Item -Path $toolsPath -ItemType Directory -Force | Out-Null
        Write-Success "Created tools directory: $toolsPath"
    }

    if (Test-Path $bfgJarPath) {
        Write-Success "BFG already downloaded at: $bfgJarPath"
    }
    else {
        Write-Host "Downloading BFG from: $bfgUrl" -ForegroundColor Yellow
        try {
            Invoke-WebRequest -Uri $bfgUrl -OutFile $bfgJarPath -UseBasicParsing
            Write-Success "BFG downloaded successfully!"
        }
        catch {
            Write-Error-Custom "Failed to download BFG automatically"
            Write-Host "Please download manually from: https://reclaimtheweb.org/license/bfg/" -ForegroundColor Yellow
            exit 1
        }
    }

    # Step 3: Create backup
    Write-Step "Step 3: Creating backup of repository"
    if (-not (Test-Path $backupPath)) {
        Write-Host "Backing up to: $backupPath" -ForegroundColor Yellow
        Copy-Item -Path $repoPath -Destination $backupPath -Recurse
        Write-Success "Backup created successfully!"
    }
    else {
        Write-Warning-Custom "Backup already exists, skipping"
    }

    # Step 4: Check repository size before cleanup
    Write-Step "Step 4: Checking current repository size"
    Set-Location $repoPath
    $sizeBefore = git count-objects -vH | Select-String "size-pack"
    Write-Host "Current size: $sizeBefore" -ForegroundColor Yellow

    # Step 5: Create mirror clone
    Write-Step "Step 5: Creating mirror clone"
    Set-Location $reposParentPath
    if (Test-Path $mirrorPath) {
        Write-Warning-Custom "Mirror clone already exists, removing old one"
        Remove-Item -Path $mirrorPath -Recurse -Force
    }

    Write-Host "Cloning mirror repository..." -ForegroundColor Yellow
    git clone --mirror https://github.com/reyesjosel/StockRoom11net030826.git $mirrorPath
    Write-Success "Mirror clone created successfully!"

    # Step 6: Run BFG to remove the file
    Write-Step "Step 6: Running BFG to remove $fileToRemove from history"
    Write-Host "This may take a few moments..." -ForegroundColor Yellow
    $bfgOutput = java -jar $bfgJarPath --delete-files $fileToRemove $mirrorPath 2>&1
    Write-Host $bfgOutput
    Write-Success "BFG processing complete!"

    # Step 7: Clean up Git objects
    Write-Step "Step 7: Cleaning up Git objects and optimizing repository"
    Set-Location $mirrorPath

    Write-Host "Expiring reflog..." -ForegroundColor Yellow
    git reflog expire --expire=now --all 2>&1 | Out-Null

    Write-Host "Running garbage collection (this may take a while)..." -ForegroundColor Yellow
    git gc --prune=now --aggressive
    Write-Success "Git cleanup complete!"

    # Step 8: Force push to GitHub
    Write-Step "Step 8: Pushing cleaned history to GitHub"
    Write-Warning-Custom "This will REWRITE history on GitHub!"
    Write-Host "Press Ctrl+C to cancel, or any other key to continue..." -ForegroundColor Yellow
    $null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")

    Write-Host "Force pushing to GitHub..." -ForegroundColor Yellow
    git push --force
    Write-Success "Successfully pushed to GitHub!"

    # Step 9: Update working repository
    Write-Step "Step 9: Updating your working repository"
    Set-Location $repoPath

    Write-Host "Fetching from origin..." -ForegroundColor Yellow
    git fetch origin

    Write-Host "Resetting to origin/main..." -ForegroundColor Yellow
    git reset --hard origin/main

    Write-Host "Cleaning local repository..." -ForegroundColor Yellow
    git reflog expire --expire=now --all 2>&1 | Out-Null
    git gc --prune=now --aggressive
    Write-Success "Working repository updated!"

    # Step 10: Clean up temporary files
    Write-Step "Step 10: Cleaning up temporary files"
    Set-Location $reposParentPath
    if (Test-Path $mirrorPath) {
        Remove-Item -Path $mirrorPath -Recurse -Force
        Write-Success "Removed mirror clone"
    }

    # Step 11: Verify results
    Write-Step "Step 11: Verifying cleanup"
    Set-Location $repoPath

    Write-Host "Checking if file exists in Git history..." -ForegroundColor Yellow
    $fileHistory = git log --all --full-history -- "wwwroot/Videos/$fileToRemove" 2>&1

    if ([string]::IsNullOrWhiteSpace($fileHistory)) {
        Write-Success "File successfully removed from Git history!"
    }
    else {
        Write-Warning-Custom "File may still exist in some commits"
        Write-Host $fileHistory
    }

    $sizeAfter = git count-objects -vH | Select-String "size-pack"
    Write-Host "`nRepository size comparison:" -ForegroundColor Cyan
    Write-Host "  Before: $sizeBefore" -ForegroundColor Yellow
    Write-Host "  After:  $sizeAfter" -ForegroundColor Green

    # Final summary
    Write-Host @"

╔══════════════════════════════════════════════════════════════╗
║                    CLEANUP COMPLETED!                        ║
╚══════════════════════════════════════════════════════════════╝

✓ Large file removed from Git history
✓ Repository optimized and pushed to GitHub
✓ Backup saved at: $backupPath

IMPORTANT NOTES:
⚠ Git history has been rewritten on GitHub
⚠ If anyone else has cloned this repo, they must re-clone it
⚠ Do not delete the backup until you verify everything works

Next steps:
1. Verify your project still builds correctly
2. Check that .gitignore prevents future large file commits
3. Consider using Git LFS for large media files in the future

"@ -ForegroundColor Green

}
catch {
    Write-Host "`n╔══════════════════════════════════════════════════════════════╗" -ForegroundColor Red
    Write-Host "║                    ERROR OCCURRED!                           ║" -ForegroundColor Red
    Write-Host "╚══════════════════════════════════════════════════════════════╝`n" -ForegroundColor Red
    Write-Host "Error: $_" -ForegroundColor Red
    Write-Host "`nBackup location: $backupPath" -ForegroundColor Yellow
    Write-Host "You can restore from backup if needed." -ForegroundColor Yellow
    exit 1
}
finally {
    # Return to original directory
    Set-Location $repoPath
}