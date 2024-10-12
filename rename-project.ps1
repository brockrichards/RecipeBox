param (
    [string]$Path = ".",
    [string]$OldString,
    [string]$NewString
)

# Check if both OldString and NewString are provided
if (-not $OldString -or -not $NewString) {
    Write-Host "Usage: script.ps1 -Path <directory> -OldString <old_string> -NewString <new_string>"
    exit
}

# Function to replace text in .cs file contents
function Replace-InFile {
    param (
        [string]$FilePath,
        [string]$OldText,
        [string]$NewText
    )

    # Read the content of the file
    $content = Get-Content -Path $FilePath -Raw

    # Replace the old text with the new text
    $newContent = $content -replace [regex]::Escape($OldText), $NewText

    # If the content was changed, write it back to the file
    if ($content -ne $newContent) {
        Set-Content -Path $FilePath -Value $newContent
        Write-Host "Replaced text in file: $FilePath"
    }
}

# Process files
$files = Get-ChildItem -Path $Path -Recurse -File

foreach ($file in $files) {    
    # Replace content
    Replace-InFile -FilePath $file.FullName -OldText $OldString -NewText $NewString
    
    # Replace string in the file names
    if ($file.Name -like "*$OldString*") {
        $newFileName = $file.Name -replace [regex]::Escape($OldString), $NewString
        $newFilePath = Join-Path -Path $file.DirectoryName -ChildPath $newFileName

        Rename-Item -Path $file.FullName -NewName $newFilePath
        Write-Host "Renamed file: $($file.FullName) to $newFilePath"
    }
}

# Then, process and rename directories
$directories = Get-ChildItem -Path $Path -Recurse -Directory | Sort-Object -Property FullName -Descending

foreach ($directory in $directories) {
    # If the directory name contains the old string, rename it
    if ($directory.Name -like "*$OldString*") {
        $newDirectoryName = $directory.Name -replace [regex]::Escape($OldString), $NewString
        $newDirectoryPath = Join-Path -Path $directory.Parent.FullName -ChildPath $newDirectoryName

        Rename-Item -Path $directory.FullName -NewName $newDirectoryPath
        Write-Host "Renamed directory: $($directory.FullName) to $newDirectoryPath"
    }
}

Write-Host "Replacement process completed."
