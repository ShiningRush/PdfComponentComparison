# PdfComponentComparition
[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/ShiningRush/PdfComponentComparition/blob/master/LICENSE)

[中文介绍请点击这里](https://github.com/ShiningRush/PdfComponentComparition/blob/master/README.zh-cn.md)

The repository is used for comparing different pdf handle component such as Aspose.Pdf , Spire.Pdf and iText so on,you also can consider it as a demo repository that show how to use those component.

## Summary

This Demo was just implemented some library(Aspose.Pdf, Spire.Pdf, iText7), some of those is commercial component.Some people maybe asked why not to choose more open-source librabry.However the most features libraries are almost charged and the most popular open-source library is iTextSharp(iText7 is its rafactor version),so i think only choosing this one is enough.

Even this demo was just implement three components,but the project is designed loosely coupled, you can realize you need component easily by implement `IPdfComponentFunc` interface, and application will add it to component's dropdownlist automatically. 

## Simple Usage Of Demo

`UseComponent` this list is used for selecting component

`InputFileDir` select the files located directory(not path) which you need to handle

`OutputFIleDir` select the directory you hope to output result

`ExecuteTimes` this is used for testing component's performance, meant excute times in total.

i think the blow button is easy to understand, just explain the button `AllRun` is meant excute all action.
