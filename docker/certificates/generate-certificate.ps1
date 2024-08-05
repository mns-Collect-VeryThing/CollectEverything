$cert = New-SelfSignedCertificate -DnsName @("pierremih.freeboxos.fr", "www.pierremih.freeboxos.fr") -CertStoreLocation "cert:\LocalMachine\My"
$certKeyPath = "c:\certs\pierremih.freeboxos.fr.pfx"
$password = ConvertTo-SecureString '123' -AsPlainText -Force
$cert | Export-PfxCertificate -FilePath $certKeyPath -Password $password
$rootCert = $(Import-PfxCertificate -FilePath $certKeyPath -CertStoreLocation 'Cert:\LocalMachine\Root' -Password $password)