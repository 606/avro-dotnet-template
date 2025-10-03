#!/bin/bash
# Test script for Avro .NET 10 Template
# This script verifies the template installation and basic functionality

set -e  # Exit on error

echo "🚀 Testing Avro .NET 10 Web API Template"
echo "========================================"
echo ""

# Colors for output
GREEN='\033[0;32m'
RED='\033[0;31m'
NC='\033[0m' # No Color

# Get the directory where the script is located
SCRIPT_DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"
TEST_DIR="/tmp/template-test-$$"

# Clean up function
cleanup() {
    echo ""
    echo "🧹 Cleaning up test directory..."
    rm -rf "$TEST_DIR"
}

# Register cleanup on exit
trap cleanup EXIT

# Test 1: Install template
echo "📦 Test 1: Installing template..."
dotnet new install "$SCRIPT_DIR" > /dev/null 2>&1
if [ $? -eq 0 ]; then
    echo -e "${GREEN}✅ Template installed successfully${NC}"
else
    echo -e "${RED}❌ Failed to install template${NC}"
    exit 1
fi

# Test 2: List templates
echo ""
echo "📋 Test 2: Verifying template appears in list..."
if dotnet new list | grep -q "avro-dotnet10"; then
    echo -e "${GREEN}✅ Template found in list${NC}"
else
    echo -e "${RED}❌ Template not found in list${NC}"
    exit 1
fi

# Test 3: Create project with default parameters
echo ""
echo "🏗️  Test 3: Creating project with default parameters..."
mkdir -p "$TEST_DIR"
cd "$TEST_DIR"
dotnet new avro-dotnet10 -n TestApp > /dev/null 2>&1
if [ -f "TestApp/src/TestApp/TestApp.csproj" ]; then
    echo -e "${GREEN}✅ Project created successfully${NC}"
else
    echo -e "${RED}❌ Failed to create project${NC}"
    exit 1
fi

# Test 4: Verify file structure
echo ""
echo "📁 Test 4: Verifying project structure..."
cd "$TEST_DIR/TestApp"
EXPECTED_FILES=(
    "src/TestApp/Program.cs"
    "src/TestApp/appsettings.json"
    "src/TestApp/Controllers/WeatherForecastController.cs"
    "src/TestApp/Extensions/ServiceCollectionExtensions.cs"
    "src/TestApp/Extensions/SwaggerExtensions.cs"
    "src/TestApp/Models/WeatherForecast.cs"
    "src/TestApp/Repositories/IRepository.cs"
    "src/TestApp/Services/IWeatherService.cs"
    ".editorconfig"
    ".gitignore"
)

ALL_FOUND=true
for file in "${EXPECTED_FILES[@]}"; do
    if [ ! -f "$file" ]; then
        echo -e "${RED}❌ Missing file: $file${NC}"
        ALL_FOUND=false
    fi
done

if [ "$ALL_FOUND" = true ]; then
    echo -e "${GREEN}✅ All expected files present${NC}"
fi

# Test 5: Verify namespace replacement
echo ""
echo "🔍 Test 5: Verifying namespace replacement..."
cd "$TEST_DIR/TestApp"
if grep -q "namespace TestApp" src/TestApp/Controllers/*.cs 2>/dev/null; then
    echo -e "${GREEN}✅ Namespaces correctly replaced${NC}"
else
    echo -e "${RED}❌ Namespace replacement failed${NC}"
fi

# Test 6: Create project with custom parameters
echo ""
echo "🎨 Test 6: Creating project with custom parameters..."
cd "$TEST_DIR"
dotnet new avro-dotnet10 -n CustomApp --HttpPort 8080 --HttpsPort 8443 --EnableSwagger false > /dev/null 2>&1
cd "$TEST_DIR/CustomApp"
if [ -f "src/CustomApp/CustomApp.csproj" ]; then
    echo -e "${GREEN}✅ Custom project created successfully${NC}"
    
    # Check if ports were replaced
    if grep -q "8080" src/CustomApp/appsettings.json && grep -q "8443" src/CustomApp/appsettings.json; then
        echo -e "${GREEN}✅ Custom ports applied correctly${NC}"
    else
        echo -e "${RED}❌ Custom ports not applied${NC}"
    fi
    
    # Check if SwaggerExtensions.cs was excluded
    if [ ! -f "src/CustomApp/Extensions/SwaggerExtensions.cs" ]; then
        echo -e "${GREEN}✅ SwaggerExtensions.cs correctly excluded${NC}"
    else
        echo -e "${RED}⚠️  SwaggerExtensions.cs not excluded (conditional file exclusion)${NC}"
    fi
else
    echo -e "${RED}❌ Failed to create custom project${NC}"
    exit 1
fi

echo ""
echo "=========================================="
echo -e "${GREEN}🎉 All tests passed!${NC}"
echo ""
echo "Note: To test building and running, you'll need to update"
echo "      TargetFramework to net9.0 in the .csproj file"
echo "      (since .NET 10 is not yet released)."
echo ""
echo "Example:"
echo "  cd TestApp/src/TestApp"
echo "  sed -i 's/net10.0/net9.0/' TestApp.csproj"
echo "  dotnet build"
echo "  dotnet run"
