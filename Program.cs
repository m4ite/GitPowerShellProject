using System;
using System.Management.Automation;
using System.IO;


// await DatabaseManager.find_add_Repositorio("C:/Users/disrct/Desktop/Portifolio");

DatabaseManager.showValues();

await DatabaseManager.deleteRepositorio("C:/Users/disrct/Desktop/Portifolio/pamella");



// GitManager.CloneRepositorio("C:/Users/disrct/Desktop/Portifolio", "https://github.com/trevisharp/pamella");


// await GitManager.Pull("C:/Users/disrct/Desktop/Portifolio/pamella");

// await GitManager.PullAll("C:/Users/disrct/Desktop/Portifolio");