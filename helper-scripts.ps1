# Template Development Helper Scripts 


# 0. Run this, to register the function Reset-Templates

# Steps once you've made and tested some improvement to an existing published package:
    
    # 1. Be in the Content folder in the terminal
    
    # 2. Confirm clean slate (i.e. only the core templates) with 'dotnet new "Tony" -l', or run Reset-Templates
    
    # 3. Install project packages for use by dotnet new from local source by pointing to a parent folder, e.g.
    #           dotnet new --install C:\GitHub\ProjectTemplates\src\Content
    
    # 4. Test the template with e.g. dotnet new apwMvc -o C:\OutsideMyRepoDeleteSoon\MvcDemo
    
    # 5. Confirm project as generate from template
    
    # 6. ++>>> Go up a level to operate in src folder <<++
    
    # 7. Edit the nuspec file as appropriate, at minimum version uplift
    
    # 8. NuGet pack with: nuget.exe pack .\AnthonyPWatts.ProjectTemplates.nuspec -OutputDirectory .\nupkg
    
    # 9. Do a clean, then try installing from the created nupkg.
    
    # 10. Go to Upload on NuGet.org and drag in the nupkg file





function Reset-Templates{
    [cmdletbinding()]
    param(
        [string]$templateEngineUserDir = (join-path -Path $env:USERPROFILE -ChildPath .templateengine)
    )
    process{
        'resetting dotnet new templates. folder: "{0}"' -f $templateEngineUserDir | Write-host
        get-childitem -path $templateEngineUserDir -directory | Select-Object -ExpandProperty FullName | remove-item -recurse
        &dotnet new --debug:reinit
    }
}
