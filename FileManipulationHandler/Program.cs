using FileManipulationHandler.Medium;

var fileWriter = new Writer();
var fileReader = new Reader();
var fileDetailsCounter = new Counter();
var keywordFilter = new KeywordFilter();

//fileReader.ReadLinesFromFileAndPrint();
//fileDetailsCounter.CountLines();
//fileDetailsCounter.CountWords();
//fileDetailsCounter.CountChars();

fileWriter.CreateFile();

//keywordFilter.Filter();