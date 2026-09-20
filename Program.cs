

using FirstMLNetModel.Models;
using Microsoft.ML;

var context = new MLContext();
var dataPath = Path.Combine(AppContext.BaseDirectory, "Data", "symptoms.csv");
var data = context.Data.LoadFromTextFile<symptomssData>(dataPath, hasHeader: true, separatorChar: ',');

var dataSplit = context.Data.TrainTestSplit(data, testFraction: 0.2);

var trainData = dataSplit.TrainSet;
var testData = dataSplit.TestSet;


var pipeline = context.Transforms.Text.FeaturizeText("Features", nameof(symptomssData.Content))
    .Append(context.Transforms.Conversion.MapValueToKey("Label", nameof(symptomssData.Category)))
    .Append(context.MulticlassClassification.Trainers.SdcaMaximumEntropy("Label", "Features"))
    .Append(context.Transforms.Conversion.MapKeyToValue("PredictedLabel"));


var model = pipeline.Fit(trainData);

var predictions = model.Transform(testData);

var metrics = context.MulticlassClassification.Evaluate(predictions, labelColumnName: "Label");
Console.WriteLine($"Macro Accuracy: {metrics.MacroAccuracy:P2}");

//var modelPath = Path.Combine(AppContext.BaseDirectory, "SymptomsModel.zip");
//context.Model.Save(model, trainData.Schema, modelPath);
//Console.WriteLine($"Model saved to: {modelPath}");

var predictionEngine = context.Model.CreatePredictionEngine<symptomssData, symptoms>(model);
/*===============================================TESTING ENV============================================*/
//var hardTests = new[]
//{
//    "I feel weak and have a mild fever after being sick for several days",
//    "I suddenly have severe chest pain and I am struggling to breathe",
//    "My knee hurts whenever I climb stairs",
//    "I have a painful red rash spreading across my arms",
//    "I keep getting a spinning sensation and have trouble maintaining my balance",
//    "I have burning in my chest after eating and frequent acid reflux",
//    "My right ear has been ringing continuously since yesterday",
//    "My heart suddenly starts beating very fast even when I am sitting",
//    "I have a mild fever, runny nose, and feel tired",
//    "I suddenly cannot move my left arm and my speech has become unclear",
//    "I feel dizzy and my heart is beating very fast",
//    "I have a headache with pressure around my eyes and a blocked nose",
//    "I feel weak and have a mild fever after being sick for several days",
//    "I suddenly have severe chest pain and I am struggling to breathe",
//    "I have stomach pain and vomiting with a very high fever"
//};

//Console.WriteLine();
//Console.WriteLine("========== HARD TEST RESULTS ==========");

//foreach (var text in hardTests)
//{
//    var input = new symptomssData
//    {
//        Content = text,
//        Category = ""
//    };

//    var result = predictionEngine.Predict(input);

//    Console.WriteLine($"{text} => {result.PredictedLabel}");
//}

//Console.WriteLine("=======================================");
//Console.WriteLine();

//============================================================
// 👆 END OF BATCH TEST 👆
//============================================================





/*===================================================================================================*/
while (true)
{
    Console.WriteLine("Enter Symptomes here (or 'exit' to quit):");
    var content = Console.ReadLine();
    if (string.Equals(content, "exit", StringComparison.OrdinalIgnoreCase))
    {
        break;
    }

    var sampleSymptoms = new symptomssData
    {
        Content = content,
    };

    var prediction = predictionEngine.Predict(sampleSymptoms);
    Console.WriteLine($"Predicted symptoms: {prediction.PredictedLabel}");
}

