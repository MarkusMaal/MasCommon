# Markuse asjade teek

Selle teegi kasutamiseks lisage projektifaili järgmised read:

```XML
    <ItemGroup>
      <ProjectReference Include="*asukoht*\MasCommon\MasCommon.csproj" />
    </ItemGroup>
```

Ja seejärel saate importida...

```C#
	using MasCommon;
```

## Verifile

Verifile on Markuse asjade komponent, mis kontrollib teatud failide olemasolu, et kindlaks teha, kas tegu on Markus asjad süsteemide seadmega või mitte ning võimaldab programmidel käituda tulemusele vastavalt.

### bool CheckVerifileTamper()

Käivitamisel saate veenduda, et Verifile2.jar räsi oleks õige, vastasel korral ei saa me kontrolli tulemust usaldada.

### string MakeAttestation()

Käivitab Verifile kontrolli ning tagastab sõne kontrolli tulemusega. Vastavalt tulemusele peaksite käituma järgmiselt:

* VERIFIED - Seade vastab Markuse asjad nõutele. Käivita programm nagu tavaliselt.
* FAILED - Kontrolli käivitamine nurjus. Tõenäoliselt probleem Java-ga, kuva veateade ja lõpeta programmi töö.
* BYPASS - Kasutaja üritas Verifile kontrolli vahele jätta. Käivita programm nagu tavaliselt, aga piira funktsionaalsust.
* LEGACY - Seade võib vastata Verifile 1.0 nõuetele, kuid puudub vajalik Verifile2.dat fail. Lõpeta programmi töö veateatega.
* TAMPERED - Kasutaja üritas muuta väljaande infot/verifile räsi käsitsi või seadme riistvara on muutunud märkimisväärselt. Lõpeta programmi töö veateatega.
* FOREIGN - Kontrolli käivitamine õnnestus, aga seade ei vasta Markuse asjad nõuetele. Kui programm on võimeline töötama ilma Markuse asjad komponentideta, käivita programm turvarežiimis. Vastasel korral peata programm veateatega.

### bool Verifile.CheckFiles(Verifile.FileScope Scope)

Veendu, et programmi jaoks vajalikud failid eksisteeriksid. Juhul kui mingid failid peaksid puuduma, sulge programm ohutult ja kuva kasutajale veateade.

## CommonConfig

Markuse arvuti asjade konfiguratsioon. Getterid ja setterid on kirjeldatud koodis ja IntelliSensega.

### void Load(string mas_root)

Laeb konfiguratsiooni määratud Markuse asjade juurkaustast (tav. kasutajaprofiil/.mas või /mas). Laaditud konfiguratsiooni saab kätte getterite kaudu.

### void Save(string mas_root)

Salvestab konfiguratsiooni. Konfiguratsiooni muutujaid saab muuta setterite kaudu.

## DesktopCommand

Liides käskluse saatmiseks DesktopIcons rakendusele. Attribuut Type defineerib käsu tüübi ja Arguments defineerib parameetrid.

### void Load(string mas_root)

Käskluse kättesaamiseks. Määrab parameetrid automaatselt vastavalt käsufaili sisule.

### void Send(string mas_root)

Võimaldab saata käskluse. Salvestab DestopIconsCommand.json faili, mille sisu vastab objekti parameetritele.

## DesktopLayout

Töölauaikoonide paigutus. Serialiseeritav, attribuudid on kirjeldatud koodis ja IDE keskkondades IntelliSense kasutamisel.

## DesktopIcon

Klass, mis defineerib töölauaikooni. Attribuudid on kirjeldatud koodis ja IDE keskkondades IntelliSense kasutamisel.

## SpecialIcon

Sarnane töölauaikooni klassile, aga võimaldab talletada mitut ikooni. Attribuudid on kirjeldatud koodis ja IDE keskkondades IntelliSense kasutamisel.

