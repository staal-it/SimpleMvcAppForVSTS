Configuration ServerConfig 
{ 

Import-DscResource -Module xWebAdministration
    Node "localhost" {   

        WindowsFeature installIIS 
        { 
            Ensure="Present" 
            Name="Web-Server" 
        }

        WindowsFeature installIISManagementConsole
        { 
            Ensure="Present" 
            Name="Web-Mgmt-Console" 
        }

        WindowsFeature installWebAspNet45
        { 
            Ensure="Present" 
            Name="Web-Asp-Net45" 
        }

		WindowsFeature installNetFramework35
        { 
            Ensure="Present" 
            Name="Net-Framework-Core" 
        }
        
        # Stop the default website 
         xWebsite DefaultSite  
         { 
             Ensure          = 'Present' 
             Name            = 'Default Web Site' 
             State           = 'Stopped' 
             PhysicalPath    = 'C:\inetpub\wwwroot' 
             DependsOn       = '[WindowsFeature]installIIS'
			 BindingInfo     = @( MSFT_xWebBindingInformation
                                 {
                                   Protocol              = "HTTP"
                                   Port                  = 81
                                 }
                             )
        }
    }    
}

ServerConfig -OutputPath "C:\DscConfiguration"

Start-DscConfiguration -Wait -Verbose -Path "C:\DscConfiguration"