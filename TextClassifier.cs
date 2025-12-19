using Microsoft.ML;

namespace MLTranslatorWinForms.ML
{
    public class TextClassifier
    {
        private readonly PredictionEngine<TextData, TextPrediction> _engine;

        public TextClassifier()
        {
            var mlContext = new MLContext();

            var data = mlContext.Data.LoadFromTextFile<TextData>(
                "data.csv", hasHeader: true, separatorChar: ',');

            var pipeline = mlContext.Transforms.Text
                .FeaturizeText("Features", nameof(TextData.Text))
                .Append(mlContext.Transforms.Conversion.MapValueToKey("Label"))
                .Append(mlContext.MulticlassClassification.Trainers
                    .SdcaMaximumEntropy())
                .Append(mlContext.Transforms.Conversion
                    .MapKeyToValue("PredictedLabel"));

            var model = pipeline.Fit(data);

            _engine = mlContext.Model
                .CreatePredictionEngine<TextData, TextPrediction>(model);
        }

        public string Predict(string userInputText)
        {
            return _engine.Predict(
                new TextData { Text = userInputText }).Prediction;
        }
    }
}
