//
//  TextField.swift
//  lolStalker
//
//  Created by Muhand Jumah on 6/2/18.
//  Copyright © 2018 Muhand Jumah. All rights reserved.
//

import UIKit

class TextField: UITextField {
    private var _borderColor: UIColor = UIColor.clear
    private var _borderColorOnSelected: UIColor = UIColor.clear
    
    var borderColor: UIColor {
        set {
            _borderColor = newValue
            layer.customBorderColor = newValue
        }
        get {
            return _borderColor
        }
    }
    var borderColorOnSelected: UIColor {
        set {
            _borderColorOnSelected = newValue
        }
        get {
            return _borderColorOnSelected
        }
    }
    
    var padding = UIEdgeInsets(top: 0, left: 0, bottom: 0, right: 0);
    
    override func becomeFirstResponder() -> Bool {
        layer.customBorderColor = borderColorOnSelected
        super.becomeFirstResponder()
        
        return true
    }
    
    override func resignFirstResponder() -> Bool {
        layer.customBorderColor = UIColor(hex: "95989A")!
        
        super.resignFirstResponder()
        
        return true
    }
    
    // Paddging for place holder
    override func placeholderRect(forBounds bounds: CGRect) -> CGRect {
        return UIEdgeInsetsInsetRect(bounds, padding)
    }
    
    // Padding for text
    override func textRect(forBounds bounds: CGRect) -> CGRect {
        return UIEdgeInsetsInsetRect(bounds, padding)
    }
    
    // Padding for text in editting mode
    override func editingRect(forBounds bounds: CGRect) -> CGRect {
        return UIEdgeInsetsInsetRect(bounds, padding)
    }
    
}

//extension CALayer {
//    var customBorderColor: UIColor {
//        set {
//            self.borderColor = newValue.CGColor
//        }
//        get {
//            return UIColor(CGColor: self.borderColor!)
//        }
//    }
//}

//class TextField: UITextField {
//    var borderColor: UIColor {
//        set {
//            layer.customBorderColor = newValue
//        }
//
//        get {
//            return self.layer.customBorderColor
//        }
//    }
//
//    var borderColorOnSelected: UIColor = UIColor.clear
//    var padding = UIEdgeInsets(top: 0, left: 0, bottom: 0, right: 0);
//
//    override func becomeFirstResponder() -> Bool {
//        layer.customBorderColor = borderColor
//        super.becomeFirstResponder()
//        return true
//    }
//
//    override func resignFirstResponder() -> Bool {
//        layer.customBorderColor = borderColorOnSelected
//        super.resignFirstResponder()
//        return true
//    }
//
//    // Paddging for place holder
//    override func placeholderRect(forBounds bounds: CGRect) -> CGRect {
//        return UIEdgeInsetsInsetRect(bounds, padding)
//    }
//
//    // Padding for text
//    override func textRect(forBounds bounds: CGRect) -> CGRect {
//        return UIEdgeInsetsInsetRect(bounds, padding)
//    }
//
//    // Padding for text in editting mode
//    override func editingRect(forBounds bounds: CGRect) -> CGRect {
//        return UIEdgeInsetsInsetRect(bounds, padding)
//    }
//
//}

extension CALayer {
    var customBorderColor: UIColor {
        set {
            self.borderColor = newValue.cgColor
        }
        get {
            return UIColor(cgColor: self.borderColor!)
        }
    }
}
