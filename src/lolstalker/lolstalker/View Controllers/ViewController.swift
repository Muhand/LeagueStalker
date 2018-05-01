//
//  ViewController.swift
//  lolstalker
//
//  Created by Muhand Jumah on 4/29/18.
//  Copyright © 2018 Muhand Jumah. All rights reserved.
//

import UIKit

class ViewController: UIViewController {
    
    //////////////////////////////////
    // Outlets
    //////////////////////////////////
    @IBOutlet var emailOutlet: UITextField!
    @IBOutlet var passwordOutlet: UITextField!
    
    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view, typically from a nib.
        
        self.hideKeyboardWhenTappedAround()
        
        // Delegates
        setUpDelegates()
        
        // Configurations
        configure()
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
    func setUpDelegates() {
        self.emailOutlet.delegate = self
        self.passwordOutlet.delegate = self
    }
    
    func configure() {
        // emailOutlet
        self.emailOutlet.layer.borderWidth = 1.0
        self.emailOutlet.layer.borderColor = UIColor.init(hexString: "#95989A").cgColor
        
        // passwordOutlet
        self.passwordOutlet.layer.borderWidth = 1.0
        self.passwordOutlet.layer.borderColor = UIColor.init(hexString: "#95989A").cgColor
    }
}

extension ViewController: UITextFieldDelegate {
    func textFieldShouldReturn(_ textField: UITextField) -> Bool {
        textField.resignFirstResponder()
        //Action
        return true
    }
    
    func textFieldDidBeginEditing(_ textField: UITextField) {
        textField.layer.borderColor = UIColor.init(hexString: "#CE9340").cgColor
    }
    
    func textFieldDidEndEditing(_ textField: UITextField) {
        textField.layer.borderColor = UIColor.init(hexString: "#95989A").cgColor
    }
}

