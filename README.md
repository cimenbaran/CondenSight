# Condensight

**Condensight** is a real-time Unity visualization of the **Factored Sampling** and **CONDENSATION (Conditional Density Propagation)** algorithm — a probabilistic particle filter used for dynamic state estimation and tracking.

The project implements a modular, SOLID-based architecture where motion, measurement, and resampling models are fully interchangeable. It is designed as both an educational visualization tool and a high-performance experimental platform.

---

## Features

- **SOLID Architecture:** Interface-driven design (`IMotionModel`, `IMeasurementModel`, `IResampler`, etc.) for maintainability and extensibility.  
- **Modular Particle Filter Core:** Easily replace or extend prediction, weighting, or resampling models.  
- **Real-Time Visualization:** Efficient rendering of thousands of live particles using Unity's instanced mesh system.  
- **Systematic Resampling:** Implements the CONDENSATION algorithm for low-variance particle selection.  
- **Configurable Models:** Parameters stored in `ScriptableObject` assets for intuitive tuning.  
- **Interactive Measurements:** Supports both mouse-based and transform-based target tracking.  
- **GPU-Ready Design:** Core architecture prepared for compute shader acceleration.

---

## Project Structure
```

Assets/
  ParticleCondensight/
    Domain/          # Core data structures and random generators
    Core/            # ParticleFilter interface and main logic
    Models/          # Motion, measurement, and resampling strategies
    Input/           # Measurement sources (mouse, transform, etc.)
    View/            # Rendering logic for particles and estimate visualization
    Config/          # ScriptableObject configuration assets
    Composition/     # MonoBehaviour controller and dependency composition


```


---

## Architecture Overview

Condensight is designed around a clear separation of concerns:

| Layer | Responsibility | Example Classes |
|-------|----------------|-----------------|
| **Domain** | Core data and utilities | `Particle`, `GaussianRandom` |
| **Core** | Particle filter orchestration | `ParticleFilter`, `IParticleFilter` |
| **Models** | Prediction, weighting, and resampling algorithms | `ConstantVelocityMotion`, `PointDistanceGaussianMeasurement`, `SystematicResampler` |
| **Input** | Observation sources | `MouseMeasurementSource`, `TransformMeasurementSource` |
| **View** | Visualization layer | `InstancedMeshRenderer` |
| **Composition** | Application assembly | `ParticleFilterController` |

---

## Getting Started

1. Clone or copy the `ParticleCondensight` folder into your Unity project.
2. Create the following ScriptableObjects in your project:
   - `FilterConfigSO`  
   - `MotionModelConfigSO`  
   - `MeasurementModelConfigSO`  
   - `ConstantVelocityMotion` (assign the MotionModelConfigSO)  
   - `PointDistanceGaussianMeasurement` (assign the MeasurementModelConfigSO)  
   - `SystematicResampler`
3. In your scene:
   - Add a `ParticleFilterController` GameObject.  
   - Add a `MouseMeasurementSource` or `TransformMeasurementSource` and assign it to the controller.  
   - Add an `InstancedMeshRenderer` component with a simple quad or sphere mesh and a material.  
   - Assign all ScriptableObjects and references in the Inspector.
4. Enter Play Mode to observe the live particle cloud tracking the target.

---

## Design Principles

Condensight adheres to the SOLID principles:

- **Single Responsibility:** Each class handles one well-defined task (motion, measurement, resampling, etc.).  
- **Open/Closed:** Components are open for extension but closed for modification through ScriptableObject-based polymorphism.  
- **Liskov Substitution:** Interfaces ensure interchangeable models behave consistently.  
- **Interface Segregation:** Small, focused interfaces define clear contracts.  
- **Dependency Inversion:** High-level logic depends on abstractions, not concrete implementations.

---

## Future Extensions

- Compute shader implementation for large-scale particle updates.  
- Alternative motion and measurement models (e.g., constant acceleration, multiple targets).  
- Residual and stratified resampling strategies.  
- 3D tracking and visualization.  
- Data logging and performance benchmarking modules.

---

## License

This project is released under the MIT License.
