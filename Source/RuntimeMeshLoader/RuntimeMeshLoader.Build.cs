// Copyright 1998-2017 Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;
using System.IO;

public class RuntimeMeshLoader : ModuleRules
{
    private string ModulePath
    {
        get { return ModuleDirectory; }
    }

    private string ThirdPartyPath
    {
        get { return Path.GetFullPath(Path.Combine(ModulePath, "../../ThirdParty/")); }
    }


    public RuntimeMeshLoader(ReadOnlyTargetRules Target) : base(Target)
	{
	    PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;

        PublicIncludePaths.AddRange(
			new string[] {
                Path.Combine(ThirdPartyPath, "assimp/include")

				// ... add public include paths required here ...
			}
		);

		PrivateIncludePaths.AddRange(
			new string[] {
                Path.Combine(ModuleDirectory, "Private"),
				// ... add other private include paths required here ...
			}
			);
			
		
		PublicDependencyModuleNames.AddRange(
				new string[]
				{
                    "Core",
					"CoreUObject",
					"Engine",
					"RHI",
					"RenderCore",
					"MeshDescription",
					"StaticMeshDescription",
					"Projects",
					// ... add other public dependencies that you statically link with here ...
					"ProceduralMeshComponent",
                }
			);


        PrivateDependencyModuleNames.AddRange(
			new string[]
			{
				"Slate",
				"SlateCore",
				// ... add private dependencies that you statically link with here ...	
                
            }
			);
		
		
		DynamicallyLoadedModuleNames.AddRange(
			new string[]
			{
            }
            );

		if ((Target.Platform == UnrealTargetPlatform.Win64))
		{
            PublicAdditionalLibraries.Add(Path.Combine(ThirdPartyPath, "assimp\\lib\\x64\\Release", "assimp-vc141-mt.lib"));

            string Destination = Path.Combine("$(BinaryOutputDir)", "assimp-vc141-mt.dll");
            string Source = Path.Combine(ThirdPartyPath, "assimp\\bin\\x64", "assimp-vc141-mt.dll");
            RuntimeDependencies.Add(Destination, Source);
        }
    }

}
