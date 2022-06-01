## Hur vi ska utföra tasks

1. Välj en task, sätt dig som medlem på den, drar över den till "In Progress".
   - Om det är flera personer utöver huvudansvarig så skall de listas i beskrivning på tasken. Bara 1 person ska vara en member på en task.<br><br>
2. Skapa en ny branch för din Task.

   - Öppna tasken:
     - På högra sidan finns det en Development tab klicka på "create new branch" som står i den nedre texten.
       ![create a branch picture](https://i.imgur.com/3q848Ou.png)
     - Namnet på branchen ska vara "task + ID".
     - Se till att den nya branchen baseras på den sprinten vi jobbar på (sprint1 just nu)).
     - Klicka "Create Branch". Det öppnas en sida till din branch.
     - Om du inte har hämtat hem repot tidigare, gå in i "Clone" och kopiera HTTPS-länken.
   - Öppna VS2022,

     - (Om du redan har det lokalt) Öppna projektet och gå in i "Git Changed". Gör en fetch, sedan byt till remote din task-branch. Annars:
       - Klicka "Clone repository".
       - Klistra in länken till repot i "Repository location".
       - Klicka på "Clone"-knappen.
       - Gå in i "Git changes" i VS2022, och ändra branch till remote task-branchen du ska arbeta på.<br><br>

3. Gör klart tasken så att Acceptence Critera uppnås.

   - Om tasken inte är färdig, skriv i commit-meddelandet WIP + vad vi har gjort.
     - git add .
     - git commit -m "#ID WIP - created method for deleting items."
     - git push<br><br>

4. När man är klar med tasken:

- Från Git-Bash, navigera till det lokala repot för projektet på valfrit sätt. Tips är högerklicka i projektmappen och välj "Git Bash here" om det finns.

  - I Git-Bash, se till att du står på din task-branch, sen skriv dessa kommandon:
    - git add .
    - git commit -m "#ID Done - 'message'"
    - git push
  - Gå in till din branch i Azure DevOps Repot:
    - Klicka på "Create a pull request"-knappen.
    - Uppe till vänster, se till att de står "taskId into (sprintbranch)"
    - Klicka på Create. Du borde kommer in på Pull Requesten.
    - Uppe till höger, klicka på "Complete".
    - Checka i "Delete taskId after merging", och "Complete associated work items after merging" om du är klar med tasken.<br><br>

  Du bör vara färdig.

Om du får en konflict kan du testa att hämta all data från sprintbranchen först och då göra en merge genom GitBash/valfi editor. 
  - I GitBash, om du står på din taskbranch:
    - git pull origin sprintbranch
  - Det bör stå att du har konflict och i vilken fil. Öppna den filen genom:
    - code {filsökväg} (kopiera filsökvägen på den fil som har konflict i GitBash)
  - Efter du har löst konflicten i VSCode eller valfri editor:
    - git add .
    - git commit -m "fixed merge-conflict when pulling from the sprintbranch".
    - git push.
  - Gå in i den pull requesten som du troligtvis skapade tidigare och gör klart den, det borde inte vara några konflikter nu.

Om du inte vet vad som ska vara kvar/ska tas bort ur konflikten, hitta vem du har konflikt med och diskutera hur ni löser det / hur det skall se ut. Om du inte hittar/får tag på den personen, kom ihåg att lyfta konflikten på daily-SCRUM.
# FlingoWebShop-AgileGroupProject
