#!/bin/bash

echo "================================"
echo "Генерация exe для Windows (x64)"
echo "================================"


mkdir -p ./dist/windows-x64/GeeksControl.Agent
mkdir -p ./dist/windows-x64/GeeksControl.Admin
mkdir -p ./dist/windows-arm64/GeeksControl.Agent
mkdir -p ./dist/windows-arm64/GeeksControl.Admin


echo ""
echo "📦 Публикация GeeksControl.Agent для Windows x64..."
cd GeeksControl.Agent
dotnet publish -c Release -r win-x64 -o ../dist/windows-x64/GeeksControl.Agent --self-contained
cd ..

echo ""
echo "📦 Публикация GeeksControl.Admin для Windows x64..."
cd GeeksControl.Admin
dotnet publish -c Release -r win-x64 -o ../dist/windows-x64/GeeksControl.Admin --self-contained
cd ..

echo ""
echo "📦 Публикация GeeksControl.Agent для Windows ARM64..."
cd GeeksControl.Agent
dotnet publish -c Release -r win-arm64 -o ../dist/windows-arm64/GeeksControl.Agent --self-contained
cd ..

echo ""
echo "📦 Публикация GeeksControl.Admin для Windows ARM64..."
cd GeeksControl.Admin
dotnet publish -c Release -r win-arm64 -o ../dist/windows-arm64/GeeksControl.Admin --self-contained
cd ..

echo ""
echo "================================"
echo "✅ Публикация завершена!"
echo "================================"
echo ""
echo "Файлы находятся в папках ./dist/windows-x64 и ./dist/windows-arm64"
echo ""
echo "Запуск приложений:"
echo "  GeeksControl.Agent.exe - Агент для сбора информации"
echo "  GeeksControl.Admin.exe - Административное приложение"
echo ""