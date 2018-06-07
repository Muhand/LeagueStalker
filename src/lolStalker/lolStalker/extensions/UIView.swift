//
//  UIView.swift
//  lolStalker
//
//  Created by Muhand Jumah on 5/31/18.
//  Copyright © 2018 Muhand Jumah. All rights reserved.
//

import Foundation
import UIKit

extension UIView {
    enum ViewSide {
        case Left, Right, Top, Bottom
    }
    
    func addConstraintsWithFormat(format: String, views: UIView...) {
        var viewsDictionary = [String: UIView]()
        for(index, view) in views.enumerated() {
            let key = "v\(index)"
            viewsDictionary[key] = view
            view.translatesAutoresizingMaskIntoConstraints = false
        }
        
        addConstraints(NSLayoutConstraint.constraints(withVisualFormat: format, options: NSLayoutFormatOptions(), metrics: nil, views: viewsDictionary))
    }
    
    func addBorder(toSide side: ViewSide, withColor color: CGColor, andThickness thickness: CGFloat, shouldClipToBounds clip: Bool? = false) {
        // Example use: myView.addBorder(toSide: .Left, withColor: UIColor.redColor().CGColor, andThickness: 1.0)
//        let border = CALayer()
//        border.backgroundColor = color
//
//        switch side {
//            case .Left: border.frame = CGRect(x: frame.minX, y: frame.minY, width: thickness, height: frame.height); break
//            case .Right: border.frame = CGRect(x: frame.maxX, y: frame.minY, width: thickness, height: frame.height); break
//            case .Top: border.frame = CGRect(x: frame.minX, y: frame.minY, width: frame.width, height: thickness); break
//            case .Bottom: border.frame = CGRect(x: frame.minX, y: frame.maxY, width: frame.width, height: thickness); break
//        }
//
//        layer.addSublayer(border)
        
        let border = CALayer()
        
        border.borderWidth = thickness
        border.borderColor = color
        
        switch side {
            case .Left:
                border.frame = CGRect(x: frame.minX, y: 0, width: thickness, height: frame.height)
                break
            case .Right:
                border.frame = CGRect(x: frame.maxX, y: 0, width: thickness, height: frame.height)
                break
            case .Top:
                border.frame = CGRect(x: 0, y: -1, width: frame.width, height: thickness)
                break
            case .Bottom:
                border.frame = CGRect(x: 0, y: frame.maxY, width: frame.width, height: thickness)
                break
        }
        
        if let clip = clip {
            clipsToBounds = clip
        } else {
            clipsToBounds = false
        }
        
        layer.addSublayer(border)
    }

}
