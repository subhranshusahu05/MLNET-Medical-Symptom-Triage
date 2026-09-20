# 🧠 Medical Symptom Triage using ML.NET

A machine learning project built with ML.NET to classify user-described
symptoms into a suggested medical specialist category.

> ⚠️ Educational Project: This project is intended for learning and
> demonstration purposes only. 

## 🎯 Project Overview

This project demonstrates how ML.NET can be used to build a
multiclass text classification model for medical symptom triage.

The model takes a text description of symptoms as input and predicts
one of the following categories:

- General Physician
- Cardiologist
- Dermatologist
- Orthopedic
- Neurologist
- Gastroenterologist
- ENT
- Emergency

## 🔄 ML Pipeline

User Symptom Text
        ↓
Text Featurization
        ↓
Label Mapping
        ↓
SDCA Maximum Entropy
        ↓
Multiclass Classification
        ↓
Predicted Specialist Category

## 🛠️ Technologies Used

- C#
- .NET
- ML.NET
- Multiclass Text Classification
- SDCA Maximum Entropy
- CSV Dataset
- Visual Studio

## 📊 Model Evaluation

Dataset Size: 850 records

The current model achieved approximately:

**92% Macro Accuracy**

The model was evaluated using an 80/20 train-test split.

> Note: This accuracy is based on the current dataset and train-test
> split. It should not be interpreted as clinical accuracy or medical
> validation.

## 🧪 Example Predictions

| Input | Prediction |
|---|---|
| Severe chest pain and difficulty breathing | Emergency |
| Knee pain while climbing stairs | Orthopedic |
| Red itchy spreading rash | Dermatologist |
| Continuous ringing in the ear | ENT |
| Fast heartbeat and palpitations | Cardiologist |

## 🎥 Demo
<img width="400" height="225" alt="Video" src="https://github.com/user-attachments/assets/95c39317-01bb-4549-bc1d-f482de0895f9" />






### YouTube Video

https://www.youtube.com/watch?v=bFa_oGMV234

## 📁 Project Structure

```text
MedicalSymptomTriage
│
├── Data
│   └── symptoms.csv
│
├── Models
│   ├── symptomssData.cs
│   └── symptoms.cs
│
├── Program.cs
