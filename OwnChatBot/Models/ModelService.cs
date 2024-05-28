namespace OwnChatBot.Models
{
    using Tensorflow;
    using static Tensorflow.Binding;

    public class ModelService
    {
        private readonly string _modelPath;
        private readonly Graph _graph;
        private readonly Session _session;

        public ModelService(string modelPath)
        {
            _modelPath = modelPath;
            _graph = new Graph().as_default();
            _session = new Session(_graph);
            _session.as_default();

            // Load the TensorFlow SavedModel
            var saver = tf.train.import_meta_graph($"{_modelPath}.meta");
            saver.restore(_session, _modelPath);
        }

        public string GenerateResponse(string input)
        {
            // Get input and output tensors from the graph
            var inputTensor = _graph.OperationByName("shape_and_slices");
            var outputTensor = _graph.OperationByName("shape_and_slices");

            // Process the input and generate a response
            var output = _session.run(outputTensor.outputs[0], new FeedItem(inputTensor, input));

            // Convert the output tensor to a string
            string response = output.ToString();

            return response;
        }
    }
}
