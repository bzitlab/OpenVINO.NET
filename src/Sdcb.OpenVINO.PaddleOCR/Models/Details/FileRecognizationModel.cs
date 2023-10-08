﻿using System.Collections.Generic;
using System.IO;

namespace Sdcb.OpenVINO.PaddleOCR.Models.Details;

/// <summary>
/// Recognization model for file processing.
/// </summary>
/// <remarks>
/// Represents a model used for file processing.
/// </remarks>
public class FileRecognizationModel : RecognizationModel
{
    private readonly IReadOnlyList<string> _labels;

    /// <summary>
    /// Gets the directory path for the model.
    /// </summary>
    public string DirectoryPath { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="FileRecognizationModel"/> class.
    /// </summary>
    /// <param name="directoryPath">The directory path for the model.</param>
    /// <param name="labelFilePath">The path for the label file.</param>
    /// <param name="version">The version of the model.</param>
    public FileRecognizationModel(string directoryPath, string labelFilePath, ModelVersion version) : base(version)
    {
        DirectoryPath = directoryPath;
        _labels = File.ReadAllLines(labelFilePath);
    }

    /// <inheritdoc/>
    public override Model CreateOVModel(OVCore core) => ReadDirectoryInferenceModel(core, DirectoryPath);

    /// <summary>
    /// Returns the label string for the given index.
    /// </summary>
    /// <param name="i">The index of the label.</param>
    /// <returns>The label string for the given index.</returns>
    public override string GetLabelByIndex(int i) => GetLabelByIndex(i, _labels);
}
