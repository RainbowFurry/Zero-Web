#params
param(
[string]$kantubasePath = "C:\Users\DarkS\source\repos\Zero_web\Zero_Web\Tools\kantu",
[string]$logPath = "C:\Users\DarkS\source\repos\Zero_web\Zero_Web\Tools\kantu\logs",
[int]$iteration,
[string]$serverUrl = "https://localhost:44338",
[int]$maxDuration = 300,
[string]$downloadPath = "C:\Users\DarkS\source\repos\Zero_web\Zero_Web\Tools\kantu\Log"
)

#test aufruf
#.\kantu.ps1 -iteration 3 -kantubasePath "c:\kantuV5" -logPath "C:/KantuV5/logs" -downloadPath "c:\Users\mhaas\Downloads\kantuChrome\"

#Init Variablen
$kantuBaseDir = dir $kantubasePath

#starte test
$chromePath = "C:/Program Files (x86)/Google/Chrome/Application/chrome.exe"  
$autorun = "file:///$kantuBasePath\autorun.html?direct=1&closeBrowser=1&closeKantu=0&savelog=log.txt&storage=xfile&&cmd_var1=$serverUrl&folder="
function startTest($test){
    Start-Sleep -s 3
    #verschiebe test in macros
    Copy-Item -Path "$kantubasePath\test\$test" -Destination "$kantubasePath\macros" -Recurse -Force
    Start-Process -FilePath $chromePath -ArgumentList "$autorun$test"
    $t = Get-Process -Name "Chrome"
    Write-Host "process: $t"
    Write-Host $downloadPath"  wird durchsucht"
    waitForLog(0)
    #lösche test aus macros
    Remove-Item -Path "$kantubasePath\macros\$test" -Recurse
    #erstelle Logs
    $firstLineOfLog = Get-Content "$downloadPath\log.txt" -TotalCount 1
    Write-Host "FirstLineOfLog: "$firstLineOfLog
    #lege log Ordner name fest > mit Iteration/Fehler
    $logFolderName = ""
    if(!($firstLineOfLog -match "Status=OK")){
        $logFolderName = "FEHLER_"
    }
    $logFolderName = "$logFolderName$test"

    mkdir -Path "$logPath\Test_$iteration" -Name "$logFolderName"
    #kopiere log von downloadPath in logPath
    Move-Item -Path "$downloadPath\*" -Destination "$logPath\Test_$iteration\$logFolderName"
}

#warte bis log.txt gefunden wurde
function waitForLog($currentDuration){
    $downloadDir = dir "$downloadPath\"
    $found = "false"
    foreach($d in $downloadDir){
        if($d.name -eq "log.txt"){
            Write-Host $d.name
            $found = "true"
        }
    }
    if($found -eq "true"){
        Write-Host "Test wurde erfolgreich abgeschlossen"
        return $found
    }elseif($currentDuration -lt $maxDuration){
        #warte 20s vor dem nächsten überprüfen
        Start-Sleep -s 20
        $currentDuration  = $currentDuration + 20
        Write-Host "warte seit "$currentDuration"s..."
        return waitForLog($currentDuration)
    }else{
        Write-Host "Test hatte einen Fehler"
        return "false";
    }
}

#erstelle test directory
$testDir = dir $kantubasePath"\test"

Write-Host $kantubasePath"\test wird durchsucht"
#erstelle Log Ordner einmalig für die Iteration
mkdir -Path $logPath -Name "Test_$iteration"

#für jeden Test
foreach( $d in $testDir){
    Write-Host "------------->> "$d.Name" <<-------------"
    startTest($d.Name)
}
