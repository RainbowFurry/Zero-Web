﻿using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Allgemeine Informationen zu einer Assembly werden über die folgenden
// Attribute gesteuert. Ändern Sie diese Attributwerte, um die Informationen zu ändern,
// die mit einer Assembly verknüpft sind.
[assembly: AssemblyTitle("Zero_Web")]
[assembly: AssemblyDescription("ZeroWorks Webside")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("ZeroWorks")]
[assembly: AssemblyProduct("Zero_Web")]
[assembly: AssemblyCopyright("Copyright ©  2020 ZeroWorks (Jason Hoffmann)")]
[assembly: AssemblyTrademark("ZeroWorks")]
[assembly: AssemblyCulture("")]

// Durch Festlegen von "ComVisible" auf "false" werden die Typen in dieser Assembly unsichtbar
// für COM-Komponenten. Wenn Sie auf einen Typ in dieser Assembly aus
// COM zugreifen müssen, legen Sie das ComVisible-Attribut für diesen Typ auf "true" fest.
[assembly: ComVisible(false)]

// Die folgende GUID bestimmt die ID der "typelib", wenn dieses Projekt für COM verfügbar gemacht wird.
[assembly: Guid("fb1a7cde-d566-4e2b-9b5b-1a822bd8ef5c")]

// Versionsinformationen für eine Assembly bestehen aus den folgenden vier Werten:
//
//      Hauptversion
//Nebenversion
//      Buildnummer
//      Revision
//
// Sie können alle Werte angeben oder die standardmäßigen Revisions- und Buildnummern
// übernehmen, indem Sie "*" eingeben:
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Cfg/log4net.config")]