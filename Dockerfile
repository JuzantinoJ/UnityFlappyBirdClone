
# Base image with Unity Editor (LTS version)
FROM unityci/editor:2021.3.20f1-webgl-1.0.1

# Set the working directory
WORKDIR /app

# Copy the entire Unity project into the Docker image
COPY . .

# Set environment variables (required for Unity builds)
ENV UNITY_LICENSE_CONTENT=""

# Default command: Open a shell
CMD ["/bin/bash"]
